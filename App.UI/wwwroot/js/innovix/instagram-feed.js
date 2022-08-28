new Vue({
    el: "#instagram-feed",
    data: {
        feed: [],
        size: null,
        profileName: "",
    },
    mounted: function mounted() {
        this.size = this.$refs.instagram.dataset["imageCount"];
        this.profileName = this.$refs.instagram.dataset["profileName"];
        this.getInstagramFeed();
    },
    methods: {
        getInstagramFeed: function () {
            let viewModel = this;
            $.get(
                "https://www.instagram.com/" + this.profileName + "/?__a=1",
                function (data, status) {
                    viewModel.feed = data.graphql.user.edge_owner_to_timeline_media.edges.slice(
                        0,
                        viewModel.size
                    );
                }
            )
        },
        windowPopup: function (event) {
            popupWindow = window.open(
                event.currentTarget.href,
                "popUpWindow",
                "height=600,width=600,left=10,top=10,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no,status=yes"
            );
        },
    },
});

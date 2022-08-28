(function () {


    //Angular implemntation of the youtube widget.
    angular.module("youtubeStreamApp", [])
        .controller("youtubeStreamController", ["$scope", "$http", function ($scope, $http) {


            $scope.getVideos = function () {
                var videosUrl = "https://www.googleapis.com/youtube/v3/search?key=" + $scope.apikey + "&channelId=" + $scope.channelId + "&part=snippet,id&order=date&maxResults=20";
                $http.get(videosUrl)
                    .success(function (data) {
                        $scope.videos = data.items;

                        $(window).on("load", function () {
                            $('.video-popup').magnificPopup({
                                disableOn: 700,
                                type: 'iframe',
                                mainClass: 'mfp-fade',
                                removalDelay: 160,
                                preloader: false,

                                fixedContentPos: false
                            });
                        });
                    })
                    .error(function (response) {
                        console.log(response);
                    });

            };
        }
        ])
        .directive('youtube', [function () {

            function link(scope, element, attrs) {
                var self = $(element)

                scope.apikey = self.data("api-key");
                scope.channelId = self.data("channel-id");

                scope.getVideos();
            }

            return {
                restrict: 'E',
                link: link
            };
        }]);
    //boostrap the ng-app manually to avoid collision with other existing ng-apps in the conatiner page
    angular.bootstrap(document.getElementById("youtubeStream"), ['youtubeStreamApp']);

}());

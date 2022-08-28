Vue.component('map-component', {
    props: ['locations', 'width', 'height', 'zoom'],
    data: function () {
        return {
            map: null,
            markers: [],
            bounds: new google.maps.LatLngBounds(),
            imagePath: "/images/icons/map-marker-icon.png"
        }
    },
    template: `<div class="map" id="map" v-bind:style="{ width: width + 'px', height: height + 'px' }"></div>`,
    mounted() {
        console.log('map component');
        this.map = this.initMap();
        this.drawMap(this.map, this.locations);
    },
    methods: {
        initMap() {
            var centeredLocation = this.locations.find(x => x.IsCenter);
            const mapElement = document.getElementById("map");
            return new google.maps.Map(mapElement, {
                zoom: this.zoom,
                center: centeredLocation != null ? { lat: centeredLocation.Location.Lat, lng: centeredLocation.Location.Long } :
                    { lat: 26.9917033, lng: 33.8968553 },
                mapTypeControl: true,
                mapTypeId: google.maps.MapTypeId.SATELLITE
            });
        },
        drawMap(map, places) {
            this.buildMarkers(map, places);

            // map.fitBounds(this.bounds);

            map.panToBounds(this.bounds);

        },

        buildMarkers(map, places) {

            this.bounds = new google.maps.LatLngBounds();

            for (let place of places) {
                var marker = this.constructMarker(map, place);
                this.bounds.extend(marker.getPosition());
            }
        },

        constructMarker(map, place) {

            var infowindow = new google.maps.InfoWindow(
                {
                    content: place.LocationLink != undefined ? this.createInfoBox(place.Name, place.LocationLink) : null
                }
            );

            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(place.Location.Lat, place.Location.Long),
                icon: { url: this.imagePath },
                map: map
            });

            marker.addListener('click', function () {
                infowindow.open(map, marker);
            });

            return marker;
        },

        createInfoBox(title, link) {

            var inbox = document.createElement("div");
            inbox.innerHTML = link != undefined ? "<p>" + title + "</p>" + "<a target='_blank' href='" + link + "'>Read More</a>" : "";
            return inbox;
        }

    }
});

new Vue({
    el: '#map-area',
    data: function () {
        return {
        }
    },
    methods: {

        constructMarker(event) {
            var currentHotel = { lat: parseFloat(event.target.getAttribute("data-lat")), lng: parseFloat(event.target.getAttribute("data-long")) };
            var map = new google.maps.Map(document.getElementById("map"), {
                zoom: parseFloat(event.target.getAttribute("data-zoom")),
                center: currentHotel,
                mapTypeId: google.maps.MapTypeId.SATELLITE
            });
            var place = {
                Name: event.target.getAttribute("data-title"),
                LocationLink: event.target.getAttribute("data-link"),
                Location: { Lat: parseFloat(event.target.getAttribute("data-lat")), Long: parseFloat(event.target.getAttribute("data-long")) }
            };


            this.$refs.setMarker.constructMarker(map, place);


        }
    }
});






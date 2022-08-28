var geocoder;
var map;
var marker;

function initializeGoogleMap(mapCanvas, txtLat, txtLng, txtZoom, hidLatitude, hidLongitude) {


    var latlng = new google.maps.LatLng(parseFloat(txtLat.val()), parseFloat(txtLng.val()));
    var myOptions = {
        zoom: parseInt(txtZoom.val()),
        center: latlng,
        mapTypeId: google.maps.MapTypeId.HYBRID
    };
    map = new google.maps.Map(mapCanvas.get(0), myOptions);

    //GEOCODER
    geocoder = new google.maps.Geocoder();

    // add a draggable marker
    marker = new google.maps.Marker({
        map: map,
        position: latlng,
        draggable: true
    });
    marker.setMap(map);

    // add a drag listener to the map
    google.maps.event.addListener(marker, "dragend", function (evt) {
        map.panTo(marker.getPosition());
        txtLat.val(evt.latLng.lat());
        txtLng.val(evt.latLng.lng());
        hidLatitude.val(evt.latLng.lat());
        hidLongitude.val(evt.latLng.lng());
    });
    // add zoom change listener
    google.maps.event.addListener(map, 'zoom_changed', function () {
        txtZoom.val(map.getZoom());
    });
}


function handelResetMap(btnReset, txtAddress, txtLat, txtLng, hidLatitude, hidLongitude, txtZoom) {
    btnReset.bind("click", function () {
        txtAddress.val(null);
        txtLat.val(0);
        txtLng.val(0);
        hidLatitude.val(0);
        hidLongitude.val(0);
        txtZoom.val(0);
    });
}

function initializeAddress(txtAddress, txtLat, txtLng, hidLatitude, hidLongitude) {

    var autocomplete = new google.maps.places.Autocomplete(txtAddress.get(0));

    google.maps.event.addListener(autocomplete, 'place_changed', function () {
        var place = autocomplete.getPlace();
        if (!place.geometry) {
            return;
        }

        // If the place has a geometry, then present it on a map.
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);  // Why 17? Because it looks good.
        }
        marker.setPosition(place.geometry.location);
        txtLat.val(marker.getPosition().lat());
        txtLng.val(marker.getPosition().lng());
        hidLatitude.val(marker.getPosition().lat());
        hidLongitude.val(marker.getPosition().lng());
    });
}

function handelDragEvent(txtAddress, txtLat, txtLng, hidLatitude, hidLongitude) {

    //Add listener to marker for reverse geocoding
    google.maps.event.addListener(marker, 'drag', function () {
        geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[0]) {
                    txtAddress.val(results[0].formatted_address);
                    txtLat.val(marker.getPosition().lat());
                    txtLng.val(marker.getPosition().lng());
                    hidLatitude.val(marker.getPosition().lat());
                    hidLongitude.val(marker.getPosition().lng());
                }
            }
        });
    });
}

$("#updateMap").click(function () {

    var lat = parseFloat($('.txtLatitude').val());
    var lng = parseFloat($('.txtLongitude').val());
    var newLatLng = new google.maps.LatLng(lat, lng);

    if (marker != undefined)
        marker.setPosition(newLatLng);
    else
        marker = new google.maps.Marker({
            position: newLatLng,
            map: map,
            draggable: true
        });
    map.setCenter(new google.maps.LatLng(lat, lng))
});

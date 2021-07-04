let map;
let infoWindow;

function initMap() {

    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 14,
        center: { lat: 39.8634529372744, lng: -4.034255487260607 }
    });

    Marker = new google.maps.Marker({
        position: { lat: 39.8634529372744, lng: -4.034255487260607 },
        map,
        draggable: true,
    });

    google.maps.event.addListener(Marker, 'dragend', function (event) {
        document.getElementById('coordsLat').value = event.latLng.lat();
        document.getElementById('coordsLng').value = event.latLng.lng();
    });

}







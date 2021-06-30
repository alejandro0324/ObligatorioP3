let map;
let infoWindow;

function initMap() {

    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 14,
        center: { lat: 39.8634529372744, lng: -4.034255487260607 }
    });

    var triangleCoords = [
        new google.maps.LatLng(39.8613, -4.0273),
        new google.maps.LatLng(39.8615, -4.0270),
        new google.maps.LatLng(39.8619, -4.0277)
    ];

    triangle = new google.maps.Polygon({
        paths: triangleCoords,
        draggable: true,
        editable: true,
        strokeColor: '#000000',
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: '#000000',
        fillOpacity: 0.35
    });

    triangle.setMap(map);
    triangle.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

    google.maps.event.addListener(triangle, "mouseover", colorChange)
    google.maps.event.addListener(triangle, "dragend", getPolygonCoords);
    google.maps.event.addListener(triangle.getPath(), "insert_at", getPolygonCoords);
    google.maps.event.addListener(triangle.getPath(), "remove_at", getPolygonCoords);
    google.maps.event.addListener(triangle.getPath(), "set_at", getPolygonCoords);

}

function colorChange() {
    const triangle = this;
    triangle.setOptions({ fillColor: document.getElementById('color').value, strokeColor: document.getElementById('color').value});
}

function showArrays(event) {
    const polygon = this;
    const vertices = polygon.getPath();
    let contentString = "";
    for (let i = 0; i < vertices.getLength(); i++) {
        const xy = vertices.getAt(i);
        contentString +=
            "Punto " + i + ":<br>" + xy.lat() + "," + xy.lng() + "<br>";
    }
    infoWindow.setContent(contentString);
    infoWindow.setPosition(event.latLng);
    infoWindow.open(map);
}

function getPolygonCoords() {
    var len = triangle.getPath().getLength();
    var select = document.getElementById("selectCoords");
    var length = select.options.length;
    for (i = length - 1; i >= 0; i--) {
        select.options[i] = null;
    }
    for (var i = 0; i < len; i++) {
        var htmlStr = "";
        htmlStr += triangle.getPath().getAt(i).toUrlValue(5);
        var option = document.createElement('option');
        option.value = option.text = htmlStr;
        select.appendChild(option);
    }
}










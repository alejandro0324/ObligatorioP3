let map;
let infoWindow;



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










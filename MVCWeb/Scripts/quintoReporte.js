window.onload = load;

function load() {
    document.getElementById("btnBuscar").onclick = buscar;
}

function buscar() {

    var valorFechaUno = document.getElementById("fechaUno").value;
    var valorFechaDos = document.getElementById("fechaDos").value;
    var json = { valorFechaUno: valorFechaUno, valorFechaDos: valorFechaDos};

    $.ajax({
        url: 'QuintoReporteSubmit',
        type: 'POST',
        data: json,
        success: function (result) {
            $("#divMapa").empty();
            $("#divMapa").html(result);
            $("#btnBuscar").remove();
        }
    });

}
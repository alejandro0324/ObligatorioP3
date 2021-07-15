window.onload = load;

function load() {
    document.getElementById("btnBuscar").onclick = buscar;
}

function buscar() {

    var valortxtCuadrilla = document.getElementById("txtCuadrilla").value;
    var json = { numero: valortxtCuadrilla };

    $.ajax({
        url: 'PrimerReporteSubmit',
        type: 'POST',
        data: json,
        success: function (result) {
            var test = result;
            $("#divTblReclamos").html(result);
        }
    });

}
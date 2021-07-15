window.onload = load;

function load() {

    document.getElementById("btnBuscar").onclick = buscar;
}

function buscar() {

    var valorTxtEstado = document.getElementById("txtEstado").value;
    var json = { estado: valorTxtEstado };

    $.ajax({
        url: 'Buscar',
        type: 'POST',
        data: json,
        success: function (result) {
            var test = result;
            $("#divTblReclamos").html(result);
        }

    });

}
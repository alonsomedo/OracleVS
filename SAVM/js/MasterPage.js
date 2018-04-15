
$("#btnManual").click(function () {
    $.ajax({
        type: "POST",
        url: "ConsultarIncidente.aspx/ListarIncidentes",
        data: {},
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuesta) {
            console.log(respuesta);
            var data = respuesta.d;
            tabla.clear();    //Limpia la tabla
            for (var i = 0; i < data.length; i++) {
                tabla.row.add([
                    data[i].Proveedor.RUC,
                    data[i].Proveedor.RazonSocial,
                    data[i].Descripcion,
                    data[i].TipoIncidencia.Descripcion,
                    data[i].FecIncidente
                ]).draw();
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        }
    });


})

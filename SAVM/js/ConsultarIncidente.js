
$(document).ready(function () {
    ListarIncidentes();
    var tabla = $("#tblIncidentes").DataTable({
        dom: 'BLrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            }
        ],
        //"dom": 'lrtip', // Oculta el filtro por defecto
        lengthChange: false, //Inhabilitamos el Mostrar10,25,50 primeros
        paging: true,
        pagingType: "numbers",
        language: {
            search: "Buscar: ",
            searchPlaceholder: "Ingrese el nombre del Proveedor o Ruc",

            lengthMenu: "Mostrar _MENU_ Primeros Resultados",
            info: "Mostrando página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles",
            zeroRecords: "",
            emptyTable: "",
            infoFiltered: ""
        }
    });

    $('#txtFiltroIncidentes').on('keyup', function () {
        tabla.search(this.value).draw();
    });

    function ListarIncidentes() {
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
    }
});


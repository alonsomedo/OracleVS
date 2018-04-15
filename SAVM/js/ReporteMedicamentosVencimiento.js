$(document).ready(function () {

    //START : FECHA 
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }
    today = dd + '/' + mm + '/' + yyyy;
    //END : FECHA


    // START: LISTAR MEDICAMENTOS
    ListarMedicamentos();
    // Filtro Medicamentos en tabla
    $('#txtFiltroMedicamento').on('keyup', function () {
        tabla.search(this.value).draw();
    });
    var tabla = $("#tblMedicamentos").DataTable({
        dom: 'BLrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5,6,7,8,9]
                }
            },
            {
                extend: 'pdfHtml5',
                orientation: 'landscape',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5,6,7,8,9]
                },
                

            }
        ],
        //"dom": 'lrtip', // Oculta el filtro por defecto
        lengthChange: false, //Inhabilitamos el Mostrar10,25,50 primeros
        paging: true,
        pagingType: "numbers",
        language: {
            search: "Buscar: ",
            searchPlaceholder: "N° Orden de Compra",

            lengthMenu: "Mostrar _MENU_ Primeros Resultados",
            info: "Mostrando página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles",
            zeroRecords: "",
            emptyTable: "",
            infoFiltered: ""
        }
    });
    function ListarMedicamentos() {
        $.ajax({
            type: "POST",
            url: "Medicamentos.aspx/ListarMedicamento",
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                console.log(respuesta);
                var data = respuesta.d;
                tabla.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    var diferenciadias = (moment((data[i].FechaVencimiento), "DD-MM-YYYY").diff(moment((today), "DD-MM-YYYY"), 'days'));
                    if (diferenciadias <= 30 && diferenciadias > 0) {
                        tabla.row.add([
                            data[i].CodMedicamento,
                            data[i].Descripcion,
                            data[i].PrecioCompra,
                            data[i].PrecioVenta,
                            data[i].Stock,
                            data[i].StockMinimo,
                            data[i].FechaVencimiento,
                            data[i].TipoMedicamento.Descripcion,
                            data[i].Proveedor.RazonSocial,
                            '<label style="color:#26b555">PROXIMO A VENCER<label>'
                        ]).draw();
                    } else if(diferenciadias < 0)
                    {
                        tabla.row.add([
                            data[i].CodMedicamento,
                            data[i].Descripcion,
                            data[i].PrecioCompra,
                            data[i].PrecioVenta,
                            data[i].Stock,
                            data[i].StockMinimo,
                            data[i].FechaVencimiento,
                            data[i].TipoMedicamento.Descripcion,
                            data[i].Proveedor.RazonSocial,
                            '<label style="color:#ff0032">VENCIDO<label>'
                        ]).draw();
                    }
                    console.log(diferenciadias);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });
    }
    //END: LISTAR MEDICAMENTOS 






});

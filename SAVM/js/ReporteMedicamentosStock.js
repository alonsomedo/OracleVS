$(document).ready(function () {

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
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                }
            },
            {
                extend: 'pdfHtml5',
                orientation: 'landscape',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                }
                

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
                var btnEditar = "<button id='btnEditarMedicamento' type='button' class='btn btn-success btn-md' style='color:white;'>Editar</button>";
                var btnEliminar = "<button id='btnEliminarMedicamento' type='button' class='btn btn-danger btn-md' style='color:white;'>Eliminar</button>";
                tabla.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    if (data[i].Stock <= data[i].StockMinimo) {
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
                            btnEditar,
                            btnEliminar
                        ]).draw();
                    }

                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });
    }


    //END: LISTAR MEDICAMENTOS 






});

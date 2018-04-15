$(document).ready(function () {


    // START: LISTAR MEDICAMENTOS
    ListarMedicamentos();


    // Filtro Medicamentos en tabla
    $('#txtFiltroMedicamento').on('keyup', function () {
        tabla.search(this.value).draw();
    });

    var tabla = $("#tblMedicamentos").DataTable({
        dom: 'lrtip', // Oculta el filtro por defecto
        lengthChange: false, //Inhabilitamos el Mostrar10,25,50 primeros
        paging: false, //Inhabilitamos paginación
        pagingType: "numbers",
        info: false,
        language: {
            search: "Buscar: ",
            searchPlaceholder: "Ingrese el nombre del Proveedor o Ruc",

            lengthMenu: "Mostrar _MENU_ Primeros Resultados",
            info: "Mostrando página _PAGE_ de _PAGES_",
            infoEmpty: "Medicamento no encontrado",
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

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });
    }


    //END: LISTAR MEDICAMENTOS 

    // START : MODAL BUSCAR PROVEEDOR
    $("#btnBuscarProveedor").click(function () {
        ListarProveedores();
    });

    $("#tblModalProveedores").on("click", "#btnAgregarProveedor", function (e) {
        var fila = $(this).closest("tr");
        $("#txtProveedor").val(fila.find("td:eq(0)").text());
        $("#modalProveedores").modal("toggle");

    });


    var tablaProveedores = $("#tblModalProveedores").DataTable({
        dom: 'lrtip', // Oculta el filtro por defecto
        lengthChange: false, //Inhabilitamos el Mostrar10,25,50 primeros
        paging: false, //Inhabilitamos paginación
        pagingType: "numbers",
        info: true,
        language: {
            infoEmpty: "Proveedor no encontrado",
            zeroRecords: "",
            emptyTable: "",
            infoFiltered: ""
        }

    });
    //Filtro Proveedores
    $('#txtFiltroProveedor').on('keyup', function () {
        tablaProveedores.search(this.value).draw();
    });

    function ListarProveedores() {

        $.ajax({
            type: "POST",
            url: "Proveedores.aspx/ListarRepProveedores",
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                var data = respuesta.d;
                var btnAgregar = "<button id='btnAgregarProveedor' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";
                tablaProveedores.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    tablaProveedores.row.add([
                        data[i].Proveedor.RUC,
                        data[i].Proveedor.RazonSocial,
                        data[i].Telefono,
                        data[i].Correo,
                        data[i].Paterno + " " + data[i].Materno + ", " + data[i].Nombre,
                        btnAgregar
                    ]).draw();
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });
    }


    // END : MODAL BUSCAR PROVEEDOR


    //START : REGISTRAR MEDICAMENTO

    $("#btnAgregarMedicamento").click(function (e) {

        if ($("#txtCodMedicamento").val() == "" || $("#txtNombreMedicamento").val() == "" || $("#txtPreComUnit").val() == "" || $("#txtPreVenUni").val() == ""
            || $("#txtStock").val() == "" || $("#txtStockMin").val() == "" || $("#txtFecVencimiento").val() == "" || $("#ddlTipoMedicamento").val() == "" || $("#txtProveedor").val() == "") {
            swal('Rellene todos los campos.', '',
                'info'
            );
            return false;
        }
        if ($("#txtCodMedicamento").val().length != 6) {
            swal('El código del medicamento debe tener 6 dígitos.', '',
                'error'
            );
            return false;
        }
        RegistrarMedicamento();
        ListarMedicamentos();
    })

    function RegistrarMedicamento() {
        var objMedicamento = JSON.stringify({
            codmedicamento: $("#txtCodMedicamento").val(),
            medicamento: $("#txtNombreMedicamento").val(),
            preComUni: $("#txtPreComUnit").val(),
            preVenUni: $("#txtPreVenUni").val(),
            stock: $("#txtStock").val(),
            stockminimo: $("#txtStockMin").val(),
            fechaVencimiento: $("#txtFecVencimiento").val(),
            tipoMedicamento: $("#ddlTipoMedicamento").val(),
            proveedor: $("#txtProveedor").val()
        });

        $.ajax({
            type: "POST",
            url: "Medicamentos.aspx/RegistrarMedicamento",
            data: objMedicamento,
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                swal('El medicamento se grabó exitosamente', '',
                    'success'
                );

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }
        });


    }

    //END : REGISTRAR MEDICAMENTO

    // START: LISTAR TIPOS DE MEDICAMENTOS

    ListarTipoMedicamento();
    function ListarTipoMedicamento() {
        $.ajax({
            type: "POST",
            url: "Medicamentos.aspx/ListarTipoMedicamento",
            data: {},
            contentType: "application/json",
            success: function (respuesta) {
                var data = respuesta.d;
                $('#ddlTipoIncidencia').empty();
                for (var i = 0; i < data.length; i++) {
                    $('#ddlTipoMedicamento').append(
                        "<option>" + data[i].Descripcion + "</option>"
                    );
                }
            }
        });
    }
    // END: LISTAR TIPOS DE MEDICAMENTOS

});
$(document).ready(function () {

    ListarProveedores();

    var tabla = $("#tblProveedores").DataTable({
        dom: 'lrtip', // Oculta el filtro por defecto
        lengthChange: false, //Inhabilitamos el Mostrar10,25,50 primeros
        paging: false, //Inhabilitamos paginación
        pagingType: "numbers",
        info:false,
        language: {
            //search: "Buscar: ",
            //searchPlaceholder: "Ingrese el nombre del proveedor",
            //lengthMenu: "Mostrar _MENU_ Primeros Resultados",
            //paging: false
            //info: "Mostrando página _PAGE_ de _PAGES_"
        }

    });


    $("#btnAgregarProveedor").click(function (e) {

        if ($("#txtRazonSocial").val() == "" || $("#txtRuc").val() == "" || $("#txtDireccion").val() == "" || $("#txtCorreo").val() == "" ||
            $("#txtNombreContacto").val() == "" || $("#txtPaterno").val() == "" || $("#txtMaterno").val() == "" || $("#txtTelefono").val() == "") {
            swal('No se digitaron los datos del Proveedor completos.', '',
                'warning'
            );
            return false;
        } else {
            RegistrarProveedor();
            ListarProveedores();
        }


    });

    function RegistrarProveedor() {
        var objProveedor = JSON.stringify({
            razonsocial: $("#txtRazonSocial").val(),
            ruc: $("#txtRuc").val(),
            direccion: $("#txtDireccion").val(),
            correo: $("#txtCorreo").val(),
            nombre: $("#txtNombreContacto").val(),
            paterno: $("#txtPaterno").val(),
            materno: $("#txtMaterno").val(),
            telefono: $("#txtTelefono").val(),
        });

        $.ajax({
            type: "POST",
            url: "Proveedores.aspx/RegistrarProveedor",
            data: objProveedor,
            dataType: "json",
            contentType: "application/json",
            success: function (respuesta) {
                //alert("Venta Registrada");
                console.log(respuesta.d);
                resultado = true;
            }, error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
                resultado = false;
            }
        });
    }

    // Filtro Proveedores en tabla
    $('#txtFiltroProveedor').on('keyup', function () {
        tabla.search(this.value).draw();
    });


    function ListarProveedores() {
        $.ajax({
            type: "POST",
            url: "Proveedores.aspx/ListarRepProveedores",
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (respuesta) {
                console.log(respuesta);
                var data = respuesta.d;
                var btnEditar = "<button id='btnEditarProveedor' type='button' class='btn btn-success btn-md' style='color:white;'>Editar</button>";
                var btnEliminar = "<button id='btnEliminarProveedor' type='button' class='btn btn-danger btn-md' style='color:white;'>Eliminar</button>";
                tabla.clear();    //Limpia la tabla
                for (var i = 0; i < data.length; i++) {
                    tabla.row.add([
                        data[i].Proveedor.RUC,
                        data[i].Proveedor.RazonSocial,
                        data[i].Proveedor.Direccion,
                        data[i].Correo,
                        data[i].Paterno + " " + data[i].Materno + ", " + data[i].Nombre,
                        data[i].Telefono,
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


    $("#tBodyProveedor").on("click", "#btnEliminarProveedor", function (e) {
        var confirmacion = confirm("¿Está seguro que desea eliminar al Proveedor?");
        if (confirmacion == true) {
            var fila = $(this).closest("tr");
            var rucproveedor = fila.find("td:eq(0)").text();
            console.log(rucproveedor);
            EliminarProveedor(rucproveedor);
        }
    });

    function EliminarProveedor(_ruc) {
        var obj = JSON.stringify({ ruc: _ruc });
        $.ajax({
            type: "POST",
            url: "Proveedores.aspx/EliminarProveedor",
            data: obj,
            dataType: "json",
            contentType: "application/json",
            success: function (respuesta) {
                swal('Proveedor eliminado Correctamente.', '',
                    'success'
                );
                ListarProveedores();
            }, error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            }


        });
    }










});
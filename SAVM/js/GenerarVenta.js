var stockmedicamento;

$(document).ready(function () {
    var hoy = new Date();
    var dia = hoy.getDate();
    var mes = hoy.getMonth() + 1;
    var year = hoy.getFullYear();

    if (dia < 10) {
        dia = '0' + dia
    }

    if (mes < 10) {
        mes = '0' + mes
    }

    hoy = dia + '/' + mes + '/' + year;

    $("#txtfecha").val(hoy);
});

function ObtenerNroVenta() {
    $.ajax({
        type: "POST",
        url: "GenerarVenta.aspx/GenerarNroVenta",
        data: {},
        async: false,
        contentType: "application/json",
        success: function (response) {
            $('#txtnumventa').val(response.d);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
        }
    });
}

$('body').on('click', '#btnAgregar', function (e) {

    if ($("#txtcodmedicamento").val() == "") {
        swal('Busque el medicamento a agregar', '',
            'warning'
        );
        return false;
    }
    var _cantidad = $("#txtcantidad").val().indexOf(".");
    if ($("#txtcantidad").val() == "" || Number($("#txtcantidad").val()) < 1 || _cantidad != -1) {
        $.toast({
            heading: 'Error',

            text: 'Ingrese la cantidad del medicamento',
            position: 'top-right',
            icon: 'error',
            loader: false,
        });
        return false;
    }
    if (Number($("#txtcantidad").val()) > stockmedicamento) {
        swal('La cantidad supera el stock del producto', '',
            'error'
        );
        return false;
    }
    var codmedicamento = $("#txtcodmedicamento").val();
    var medicamento = $("#txtnombre").val();
    var precio = $("#txtprecio").val();
    var cantidad = $("#txtcantidad").val();
    var subtotal = parseFloat(precio * cantidad).toFixed(2);
    var botonEliminar = "<button id='btnEliminar' type='button' class='btn btn-danger btn-md' style='color:white;'>Eliminar</button>";
    $('#tabladetalleventa').append("<tr>" +
        "<td>" + codmedicamento + "</td>" +
        "<td>" + medicamento + "</td>" +
        "<td>" + precio + "</td>" +
        "<td>" + cantidad + "</td>" +
        "<td>" + subtotal + "</td>" +
        "<td>" + botonEliminar + "</td>" +
        "</tr > ");
    ActualizarMontosSumar(subtotal);
    $("#txtcodmedicamento").val("");
    $("#txtnombre").val("");
    $("#txtprecio").val("");
    $("#txtcantidad").val("");
});

function ActualizarMontosSumar(subtotal) {
    var anterior = $("#txtmontototal").val();
    if (anterior == "") {
        anterior = "0";
    }
    $("#txtmontototal").val((Number(anterior) + Number(subtotal)).toFixed(2));
    calcularIGVMonto($("#txtmontototal").val());
}

$('#tabladetalleventa').on('click', '#btnEliminar', function () {
    var respuesta = confirm("¿Está seguro de eliminar el medicamento de la grilla?");
    if (respuesta == true) {
        var fila = $(this).closest('tr');
        fila.remove();
        var subtotal = Number(fila.find('td:eq(4)').text());
        ActualizarMontosRestar(subtotal);
    }
});

function ActualizarMontosRestar(subtotal) {
    var anterior = $("#txtmontototal").val();
    if (anterior == "") {
        anterior = "0";
    }
    $("#txtmontototal").val((Number(anterior) - Number(subtotal)).toFixed(2));
    calcularIGVMonto($("#txtmontototal").val());
}

function calcularIGVMonto(monto) {
    var monto_sin_igv = (monto * 0.82).toFixed(2);
    var igv = (monto * 0.18).toFixed(2);
    $("#txtmonto").val(monto_sin_igv);
    $("#txtigv").val(igv)
}



function RegistrarVentaAJAX() {

    var resultado = false;

    var obj = JSON.stringify({
        _Codventa: $("#txtnumventa").val(),
        _FecVenta: $("#txtfecha").val(),
        _Igv: $("#txtigv").val(),
        _Total: $('#txtmontototal').val()
    });

    $.ajax({
        type: "POST",
        url: "GenerarVenta.aspx/RegistrarVenta",
        data: obj,
        dataType: "json",
        async: false,
        contentType: "application/json",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
            resultado = false;
        },
        success: function (respuesta) {
            //alert("Venta Registrada");
            console.log(respuesta.d);
            resultado = true;
        }
    });
    return resultado;
}

function RegistrarDetalle() {
    $("#tabladetalleventa tr").each(function () {
        var fila = $(this).closest('tr');
        var precio = Number(fila.find('td:eq(2)').text());
        var cantidad = Number(fila.find('td:eq(3)').text());
        var subtotal = Number(fila.find('td:eq(4)').text());
        var codmedicamento = fila.find('td:eq(0)').text();
        var codventa = $("#txtnumventa").val();
        RegistrarDetalleAJAX(precio, cantidad, subtotal, codmedicamento, codventa);
    });
}

function RegistrarDetalleAJAX(precio, cantidad, subtotal, codmedicamento, codventa) {
    var obj = JSON.stringify({
        _precio: precio,
        _cantidad: cantidad,
        _subtotal: subtotal,
        _codmedicamento: codmedicamento,
        _codventa: codventa
    });
    $.ajax({
        type: "POST",
        url: "GenerarVenta.aspx/RegistrarDetalleVenta",
        data: obj,
        dataType: "json",
        async: false,
        contentType: "application/json",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
        },
        success: function (respuesta) {
        }
    });
}

function ValidarCampos() {
    if ($("#txtnumdoc").val() == "" || Number($("#txtnumdoc").val()) < 1 || $("#txtrs").val() == "") {
        swal('Ingresa datos del cliente', '',
            'warning'
        );
        return false;
    }
    var filas = Number($('#tabladetalleventa tr').length);
    if (filas <= 0) {
        swal('Agregue al menos un medicamento a la grilla', '',
            'info'
        );
        return false;
    }
    return true;
}

function Limpiar() {
    $("#txtnumdoc").val("");
    $("#txtrs").val("");
    $("#txtcodmedicamento").val("");
    $("#txtnombre").val("");
    $("#txtprecio").val("");
    $("#txtcantidad").val("");
    $("#txtnumventa").val("");
    $("#txtmonto").val("");
    $("#txtigv").val("");
    $("#txtmontototal").val("");
    $("#tabladetalleventa").empty();
}

$("#btnBuscarMedicamento").click(function (e) {
    e.preventDefault();
    ListarMedicamentosVenta();
});

function ListarMedicamentosVenta() {
    $.ajax({
        type: "POST",
        url: "Medicamentos.aspx/ListarMedicamento",
        data: {},
        contentType: "application/json",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText + "\n" + thrownError);
        },
        success: function (respuesta) {
            var data = respuesta.d;
            $("#tablaMedicamentosVenta").empty();
            var btnAgregar = "<button id='btnAgregarMedicamento' type='button' class='btn btn-success btn-md' style='color:white;'>Agregar</button>";
            for (var i = 0; i < data.length; i++) {
                $("#tablaMedicamentosVenta").append("<tr>" +
                    "<td>" + data[i].CodMedicamento + "</td>" +
                    "<td>" + data[i].Descripcion + "</td>" +
                    "<td>" + data[i].PrecioVenta + "</td>" +
                    "<td>" + data[i].Stock + "</td>" +
                    "<td>" + data[i].FechaVencimiento + "</td>" +
                    "<td>" + data[i].TipoMedicamento.Descripcion + "</td>" +
                    "<td>" + data[i].Proveedor.RazonSocial + "</td>" +
                    "<td>" + btnAgregar + "</td>" +
                    "</tr > ");
            }
        }
    });
}

$("#tablaMedicamentosVenta").on('click', '#btnAgregarMedicamento', function (e) {
    e.preventDefault();
    var fila = $(this).closest('tr');
    $("#txtcodmedicamento").val(fila.find('td:eq(0)').text());
    $("#txtnombre").val(fila.find('td:eq(1)').text());
    $("#txtprecio").val(fila.find('td:eq(2)').text());
    stockmedicamento = fila.find('td:eq(3)').text();
    $('#modalMedicamentos').modal('toggle');
});

$("#btnGrabar").click(function (e) {
    e.preventDefault();

    var flag = ValidarCampos();
    var resultado = false;
    if (flag) {
        ObtenerNroVenta();
        RegistrarVentaAJAX();
        RegistrarDetalle();

        swal({
            title: "La venta se genero con éxito",
            text: "",
            type: "success"
        },
            function PrintModal() {
                var idventa = $("#txtnumventa").val();
                var cliente = $("#txtrs").val();
                var idCliente = $("#txtnumdoc").val();
                var monto = $("#txtmonto").val();
                var igv = $("#txtigv").val();
                var montototal = $("#txtmontototal").val();
                $("#txtNomCliente").val(cliente);
                $("#txtIdCliente").val(idCliente);
                $("#txtPrtMonto").val(monto);
                $("#txtPrtIgv").val(igv);
                $("#txtPrtMontoTotal").val(montototal);
                $("#nroVenta").text(idventa);
                $("#prtTableDetalleVenta").empty();
                copiarTablaDetalle('tblDetVenta', 'prtTableDetalleVenta', 0, 1, 2, 3, 4)
                $("#printVenta").printThis();
            });

        //Limpiar();
    }
});




//Copia la tabla detalle a la tabla del modal
function copiarTablaDetalle(sourceTableId, targetTableId) {
    var colNos = [].slice.call(arguments, 2),
        $target = $("#" + targetTableId);
    $("#" + sourceTableId + " tr").each(function () {
        var $tds = $(this).children(),
            $row = $("<tr></tr>");
        for (var i = 0; i < colNos.length; i++)
            $row.append($tds.eq(colNos[i]).clone());
        $row.appendTo($target);
    });
};


//Se usa fun
$("#txtBuscarMedicamento").keyup(function () {
    //split the current value of searchInput
    var data = this.value.split(" ");
    //create a jquery object of the rows
    var jo = $("#tablaMedicamentosVenta").find("tr");
    if (this.value == "") {
        jo.show();
        return;
    }
    //hide all the rows
    jo.hide();

    //Recusively filter the jquery object to get results.
    jo.filter(function (i, v) {
        var $t = $(this);
        for (var d = 0; d < data.length; ++d) {
            if ($t.text().toUpperCase().indexOf(data[d]) > -1) {
                return true;
            }
        }
        return false;
    })
        //show the rows that match.
        .show();
}).focus(function () {
    this.value = "";
    $(this).css({
        "color": "black"
    });
    $(this).unbind('focus');
}).css({
    "color": "#C0C0C0"
});


function changeToUpperCase(t) {
    var eleVal = document.getElementById(t.id);
    eleVal.value = eleVal.value.toUpperCase().replace(/ /g, '');
}
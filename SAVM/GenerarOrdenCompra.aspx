<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GenerarOrdenCompra.aspx.cs" ClientIDMode="Static"
    Inherits="SAVM.GenerarOrdenCompra" %>
<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content_GOC" ContentPlaceHolderID="MainContent" runat="server">
    <header class="titulo">
        <div class="container-fluid">
            <h2 style="text-align: left"><strong>Generar Orden de Compra</strong></h2>
        </div>
    </header>
    <div class="container-fluid">
        <br>
        <div class="row">
            <fieldset class="col-md-6">
                <legend>Datos de Proveedor</legend>
                RUC:
					
                <div class="row">
                    <div class="col-md-6">
                        <input type="text" class="form-control" id="txtrucOC" disabled>
                    </div>
                    <div class="col-md-6">
                        <button type="button" class="btn btn-primary" id="btnBuscarProveedor"
                            data-toggle="modal" data-target="#modalProveedores">
                            Buscar Proveedor
								
                        </button>
                    </div>
                </div>
                <br>
                Razón Social:
					
                <div class="row">
                    <div class="col-md-6">
                        <input type="text" class="form-control" id="txtrazonsocialOC" disabled>
                    </div>
                    <div class="col-md-6">


                        <input type="button" class="btn btn-primary" id="btnRegistrarProveedor" value="Registrar Proveedor" onclick="window.open('Proveedores.aspx')">
                        <%--<input type="button" data-toggle="modal" data-target="#modalRegPro" class="btn btn-primary" id="btnRegistrarProveedor" value="Registrar Proveedor">--%>
                    </div>
                </div>
                <br>
                Contacto:
					
                <input type="text" class="form-control" id="txtcontactoOC" disabled><br>
                <br>
            </fieldset>

            <fieldset class="col-md-6">
                <legend>Datos del Medicamento</legend>
                Código:
					
                <div class="row">
                    <div class="col-md-6">
                        <input type="text" class="form-control" id="txtcodmedicamentoOC" disabled>
                    </div>
                    <div class="col-md-6">
                        <button type="button" class="btn btn-primary" id="btnBuscarMedicamentoOC"
                            data-toggle="modal" data-target="#modalMedicamentosOC">
                            Buscar Medicamento
								
                        </button>
                    </div>
                </div>
                Nombre:
					
                <div class="row">
                    <div class="col-md-6">
                        <input type="text" class="form-control" id="txtnombreOC" disabled>
                    </div>
                    <div class="col-md-6">
                        <input type="button" class="btn btn-primary" value="Registrar Medicamento" onclick="window.open('Medicamentos.aspx')">
                        <%--      <input type="button" class="btn btn-primary" value="Registrar Medicamento" onclick="location.href = '/Medicamentos.aspx'">--%>
                    </div>
                </div>
                Precio Unit.:
					
                <div style="width: 100px">
                    <input type="number" class="form-control" id="txtprecioOC" disabled>
                </div>
                Cantidad:
					
                <div class="row">
                    <div class="col-md-3">
                        <input type="number" class="form-control" id="txtcantidadOC">
                    </div>
                    <div class="col-md-6 col-md-offset-3">
                        <input type="button" class="btn btn-primary" value="Agregar Medicamento" id="btnAgregarOC">
                    </div>
                </div>
                <br>
            </fieldset>
        </div>
        <br>
        <div class="row">
            <fieldset>
                <legend>Datos de la O/C</legend>
                <div class="row">
                    <div class="form-inline col-md-8">
                        <!--NUMERO DE ORDEN DE COMPRA -->
                        <input type="text" class="form-control" style="width: 100px;" id="txtnumocOC" disabled="disabled">
                    </div>
                    <div class="form-inline col-md-4 ">
                        <label for="txtfechaOC">Fecha:</label>&nbsp;&nbsp;&nbsp;
					
                        <input type="text" class="form-control" id="txtfechaOC" disabled>
                    </div>
                </div>
                <br>
                <div class="panel bg-blue-gradient" style="overflow: auto">
                    <table class="table" id="tblDetOC">
                        <thead>
                            <tr>
                                <th>Cod. Med</th>
                                <th>Medicamento</th>
                                <th>PUnitario</th>
                                <th>Cantidad</th>
                                <th>Subtotal</th>
                                <th>Opcion</th>
                            </tr>
                        </thead>
                        <tbody id="tableDetalleBodyOC">
                        </tbody>
                    </table>
                </div>
                <br>
                <br>
                <br>
                <br>
                <div class="col-md-offset-9 col-md-2">
                    Monto:
					
                    <input type="number" class="form-control" id="txtmontoOC" disabled>
                    I.G.V(18%):
					
                    <input type="number" class="form-control" id="txtigvOC" disabled>
                    Monto Total:
					
                    <input type="number" class="form-control" id="txtmontototalOC" disabled><br>
                </div>
            </fieldset>
        </div>
        <br>
        <div class="row">

            <div class="col-md-1">
                <input type="button" class="btn btn-primary" value="Volver" onclick="location.href = '/Index.aspx'">
            </div>
            <div class="col-md-6">
                <input type="button" class="btn btn-success" value="Grabar" id="btnGrabarOC">
            </div>
            <br>
            <br>
        </div>
    </div>


    <!-- Modal Medicamentos-->
    <div class="modal fade" id="modalMedicamentosOC" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content modal-lg" style="overflow: auto; height: 600px">
                <!-- Modal Header -->
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title">Medicamentos</h4>
                </div>

                <!-- Modal Body -->
                <div class="modal-body">
                    <p class="statusMsg"></p>
                    <input type="text" onkeyup="changeToUpperCase(this)" placeholder="Ingrese criterio de búsqueda" class="form-control" id="txtBuscarMedicamentoOC">
                    <br>
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <td>Cod. Med</td>
                                <td>Medicamento</td>
                                <td>Precio</td>
                                <td>Stock</td>
                                <td>Fec. Venc</td>
                                <td>Tipo</td>
                                <td>Proveedor</td>
                                <td>Opción</td>
                            </tr>
                        </thead>
                        <tbody id="tablaMedicamentosOC">
                        </tbody>
                    </table>
                </div>

                <!-- Modal Footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Start: Modal Proveedores-->
    <div class="modal fade" id="modalProveedores" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content modal-lg" style="overflow: auto; height: 600px">
                <!-- Modal Header -->
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title">Proveedores</h4>
                </div>

                <!-- Modal Body -->
                <div class="modal-body">
                    <p class="statusMsg"></p>
                    <input type="text" onkeyup="changeToUpperCase(this)" placeholder="Ingrese criterio de búsqueda" class="form-control" id="txtBuscarProveedor">
                    <br>
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <td>RUC</td>
                                <td>Razón Social</td>
                                <td>Telefono</td>
                                <td>Correo</td>
                                <td>Dirección</td>
                                <td>Contacto</td>
                            </tr>
                        </thead>
                        <tbody id="tablaProveedoresModal">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!-- End: Modal Proveedores-->
    <!--Start Modal: Imprimir -->
    <div class="modal fade" id="modalPrintOC" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content modal-lg">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title" id="modalNroOC"></h4>
                </div>
                <div class="modal-body" id="printOC">

                    <h2>ORDEN DE COMPRA NÚMERO:<label id="nroOC"></label></h2>
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group col-md-6 col-lg-6">
                            <label for="txtRS">Razón Social</label>
                            <input type="text" id="txtRS" class="form-control" name="nombrecliente" value="" />
                        </div>
                        <div class="form-group col-md-6 col-lg-6">
                            <label for="txtRuc">RUC</label>
                            <input type="number" id="txtRuc" class="form-control" name="idcliente" value="" />
                        </div>
                    </div>
                    <div>
                        <h4>DETALLE DE ORDEN DE COMPRA </h4>
                        <br />
                        <table id="prtTableDetalleOC" class="table table-bordered table-hover">
                        </table>
                    </div>
                    <div class="col-md-12 col-lg-12">
                        <div class="form-group">
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label for="txtPrtMonto">MONTO S/.</label>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <input class="form-control" type="text" id="txtPrtMonto" name="prtmonto" value="" />
                            </div>

                        </div>
                        <div class="form-group">
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label for="txtPrtIgv">IGV</label>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <input class="form-control" type="text" id="txtPrtIgv" name="prtigv" value="" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label for="txtPrtMontoTotal">MONTO TOTAL S/.</label>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <input class="form-control" type="text" id="txtPrtMontoTotal" name="prtmontototal" value="" />
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- End Modal: Imprimir -->

    <!--Start Modal: Registrar Proveedor -->
    <div class="modal fade" id="modalRegPro" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header" style="background-color: dodgerblue">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel">DATOS DEL PROVEEDOR</h4>
                </div>

                <!-- Modal Body -->
                <div class="modal-body">
                    <p class="statusMsg"></p>
                    <fieldset>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-4">
                                        <p>Razón Social:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProRazonSocial" type="text" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                                <br>

                                <div class="row">
                                    <div class="col-md-4">
                                        <p>RUC:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProRuc" type="number" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                                <br>

                                <div class="row">
                                    <div class="col-md-4">
                                        <p>Dirección:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProDireccion" type="text" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                                <br>


                                <div class="row">
                                    <div class="col-md-4">
                                        <p>Correo Electrónico:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProCorreo" type="text" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-4">
                                        <p>Nombre Contacto:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProContacto" type="text" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                                <br>

                                <div class="row">
                                    <div class="col-md-4">
                                        <p>Apellido Paterno:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProConPaterno" type="text" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                                <br>

                                <div class="row">
                                    <div class="col-md-4">
                                        <p>Apellido Materno:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProConMaterno" type="text" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                                <br>


                                <div class="row">
                                    <div class="col-md-4">
                                        <p>Teléfono:</p>
                                    </div>
                                    <div class="col-md-6">
                                        <input id="txtProTelefono" type="number" name="name" value="" class="form-control" />
                                    </div>
                                </div>
                                <br>
                            </div>
                        </div>
                    </fieldset>
                    <br />
                    <div style="text-align: center">
                        <button type="button" id="btnGrabarProveedor" class="btn btn-primary">Grabar</button>&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>


                </div>
            </div>
        </div>
    </div>
    <!-- End Modal: Registrar Proveedor -->




</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="footer" runat="server">
    <script src="js/GenerarOrdenCompra.js"></script>
    <script src="plugins/printThis.js"></script>
</asp:Content>

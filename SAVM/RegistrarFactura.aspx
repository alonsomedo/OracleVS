<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RegistrarFactura.aspx.cs" Inherits="SAVM.RegistrarFactura" %>
<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <br>
        <div class="row">
            <fieldset class="col-md-6">
                <legend>Datos del Proveedor</legend>
                RUC
						<div class="row">
                            <div class="col-md-7">
                                <input id="txtRucProveedor" disabled="disabled" type="number" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <input type="button" data-toggle="modal" data-target="#modalProveedores" id="btnBuscarProveedor" class="form-control btn btn-primary" value="Buscar Proveedor">
                            </div>
                        </div>
                <br>
                Razón Social:
						<div class="row">
                            <div class="col-md-7">
                                <input id="txtRazonSocial" disabled="disabled" type="text" class="form-control">
                            </div>
                        </div>
                <br>
            </fieldset>

            <fieldset class="col-md-6">
                <legend>Datos del Medicamento</legend>
                Cód. Medicamento:
                <div class="row">
                            <div class="col-md-6">
                                <input type="text" disabled="disabled" id="txtCodMedicamento" class="form-control">
                            </div>
                            <div class="col-md-6">
                                <input type="button" id="btnBuscarMedicamentos" data-toggle="modal" data-target="#modalMedicamentos" class="btn btn-primary" value="Buscar Medicamento">
                            </div>
                </div>
                Medicamento:
                            <div class="">
                                <input type="text" disabled="disabled" id="txtNomMedicamento" class="form-control" style="width: 250px">
                            </div>
                Precio:
						<div style="width: 115px">
                            <input type="number" id="txtPrecio" class="form-control">
                        </div>
                Cantidad:
						<div class="row">
                            <div class="col-md-3">
                                <input type="number" id="txtCantidad" class="form-control">
                            </div>
                            <div class="col-md-6 col-md-offset-3">
                                <input type="button" id="btnAgregar" class="btn btn-primary" value="Agregar Medicamento">
                            </div>
                        </div>
                <br>
            </fieldset>
        </div>
        <br>
        <div class="row">
            <fieldset>
                <legend>Datos de la Factura</legend>
                <div class="row">
                    <div class="col-md-8 form-inline">
                        <label>N° de la Factura:</label>&nbsp;&nbsp;&nbsp;
						<input id="txtNumeroFactura" type="text" class="form-control" style="width: 100px">
                    </div>

                    <div class="form-inline col-md-4">
                        <label for="">Fecha:</label>&nbsp;&nbsp;&nbsp;
						<input id="txtFecha" type="date" id="txtFecha" class="form-control">
                    </div>
                </div>
                <br>

                <table id="tblDetalleFactura" class="table">
                    <thead>
                        <tr>
                            <td>CodMedicamento</td>
                            <td>Medicamento</td>
                            <td>PUnitario</td>
                            <td>Cantidad</td>
                            <td>Total</td>
                            <td>Opción</td>
                        </tr>
                    </thead>
                    <tbody id="tblBodyDetalleFactura">

                    </tbody>
                </table>
                <br>
                <br>
                <br>
                <br>
                <div class="col-md-offset-9 col-md-2">
                    Monto Total:
						<input id="txtmontototal" type="number" class="form-control" disabled="disabled"><br>
                </div>
            </fieldset>
        </div>
        <br>
        <div class="row">
            <div class="col-md-1">
                <input type="button" class="btn btn-primary" value="Volver">
            </div>
            <div class="col-md-6">
                <input type="button" id="btnGrabar" class="btn btn-success" value="Grabar">
            </div>
            <br>
            <br>
        </div>
    </div>


    <!-- Start: Modal Proveedores-->
    <div class="modal fade" id="modalProveedores" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content modal-lg" style="overflow: auto; height: 800px">
                <!-- Modal Header -->
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title">LISTADO DE PROVEEDORES</h4>
                </div>

                <!-- Modal Body -->
                <div class="modal-body">
                    <div>
                        <table class="datatable table table-responsive table-bordered table-hover table-striped" id="tblProveedores">
                            <thead>
                                <tr>
                                    <th>RUC</th>
                                    <th>Razón Social</th>
                                    <th>Telefono</th>
                                    <th>Correo</th>
                                    <th>Dirección</th>
                                    <th>Contacto</th>
                                    <th>Accion</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>


            </div>
        </div>
    </div>
    <!-- End: Modal Proveedores-->

    <!-- Start: Modal Medicamentos -->
    <div class="modal fade" id="modalMedicamentos" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content modal-lg" style="overflow: auto; height: 800px">
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
                    <div>
                        <table id="tblMedicamentos" class="datatable table table-responsive table-bordered table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Cod. Med</th>
                                    <th>Medicamento</th>
                                    <th>Precio</th>
                                    <th>Stock</th>
                                    <th>Fec. Venc</th>
                                    <th>Tipo</th>
                                    <th>Proveedor</th>
                                    <th>Opción</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- End: Modal Medicamentos -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/RegistrarFactura.js"></script>
</asp:Content>

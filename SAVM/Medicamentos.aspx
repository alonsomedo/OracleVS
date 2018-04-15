<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Medicamentos.aspx.cs" Inherits="SAVM.Medicamentos" %>
<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <header class="titulo">
        <div class="container-fluid">
            <h2 style="text-align: left"><strong>Registrar Medicamento</strong></h2>
        </div>
    </header>
    <div class="container-fluid">
        <br>
        <fieldset>
            <legend>Datos del Medicamento</legend>
            <div class="row">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Cod.Medicamento:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtCodMedicamento" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <p>Nombre de Medicamento:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtNombreMedicamento" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Prec. Compra Unit.:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtPreComUnit" type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Prec. Venta Unit.:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtPreVenUni" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>


                    <div class="row">
                        <div class="col-md-4">
                            <p>Stock:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtStock" type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Stock Mínimo:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtStockMin" type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <p>Fecha de Vencimiento:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtFecVencimiento" type="date" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Tipo de Medicamento:</p>
                        </div>
                        <div class="col-md-5">
                            <select id="ddlTipoMedicamento" class="form-control"></select>
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Proveedor:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtProveedor" type="text" name="name" value="" class="form-control" />
                        </div>
                        <div class="col-md-3">
                            <input class="btn btn-primary" id="btnBuscarProveedor" data-toggle="modal" data-target="#modalProveedores" type="button" name="name" value="Buscar Proveedor" />
                        </div>
                    </div>
                    <br>
                </div>
            </div>
        </fieldset>
        <br>
        <div class="">
            <input type="button" id="btnAgregarMedicamento" class="btn btn-success" value=" ➕ Agregar Medicamento">
        </div>
        <br />
        <div class="row">
            <div class="col-md-11">
                <input type="text" id="txtFiltroMedicamento" name="name" value="" placeholder=" 🔍 Ingrese Código o Nombre de Medicamento" class="form-control" />
            </div>
        </div>
        <br>
        <div class="row">
            <div class="col-md-12" style="overflow: auto; height: 300px">
                <table class="table" id="tblMedicamentos">
                    <thead class="bg-blue-gradient">
                        <tr>
                            <th>CodMedicamento</th>
                            <th>Medicamento</th>
                            <th>P.Compra</th>
                            <th>P.Venta</th>
                            <th>Stock</th>
                            <th>StockMin.</th>
                            <th>Fec.Vencimiento</th>
                            <th>Tipo</th>
                            <th>Proveedor</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="tBodyMedicamentos">
                    </tbody>
                </table>
            </div>
        </div>

        <div class="row">
            <div class="col-md-1">
                <input type="button" class="btn btn-primary" value="Volver">
            </div>
        </div>
    </div>
    <!-- Start: Modal Buscar Proveedores-->
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
                    <input type="text" placeholder="Ingrese criterio de búsqueda" class="form-control" id="txtFiltroProveedor">
                    <br>
                    <div >
                        <table id="tblModalProveedores"  class="datatable table table-responsive table-bordered table-hover table-striped">
                            <thead style="background:#5994f2; color:white">
                                <tr>
                                    <th>RUC</th>
                                    <th>Razón Social</th>
                                    <th>Telefono</th>
                                    <th>Correo</th>
                                    <th>Dirección</th>
                                    <th>Contacto</th>
                                </tr>
                            </thead>
                            <tbody >
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- End: Modal Buscar Proveedores-->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/Medicamentos.js"></script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConsultarOrdenCompra.aspx.cs" ClientIDMode="Static" Inherits="SAVM.ConsultarOrdenCompra" %>
<%@ OutputCache Location="None" NoStore="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h3>Consultar Órdenes de Compra de Medicamentos</h3>

        <div class="form-inline">
            <span class="fa fa-search"></span>
            <input type="text" id="txtFilterOC" name="name" style="width: 88%" placeholder=" Buscar O/C" class="form-control" />

        </div>
        <br>
        <div class="col-md-11 panel bg-white-gradient" style="height: 700px; overflow: auto">
            <table id="tblOrdenCompra" class="table table-condensed ">
                <thead>
                    <tr>
                        <th>N° de O/C</th>
                        <th>Fecha de Emisión</th>
                        <th>IGV</th>
                        <th>Total S/.</th>
                        <th>RUC Proveedor</th>
                        <th>R.Social</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
        <div class="col-md-offset-9 col-md-2">
            <input type="button" name="name" class="form-control btn btn-primary" value="Volver" />
        </div>
    </div>

    <!-- Start: Modal Detalle Orden de Compra-->
    <div class="modal fade" id="modalDetalleOC" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content modal-lg" style="overflow: auto; height: 500px">
                <!-- Modal Header -->
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title">Detalle Orden de Compra</h4>
                </div>

                <!-- Modal Body -->
                <div class="modal-body">
                    <div>
                        <table id="tblDetalleOC" class=" table table-striped table-bordered dataTable no-footer">
                            <thead>
                                <tr>
                                    <th>N° Detalle</th>
                                    <th>CodMedicamento</th>
                                    <th>Medicamento</th>
                                    <th>P.Unitario</th>
                                    <th>Cantidad</th>
                                    <th>Subtotal</th>
                                </tr>
                            </thead>
                            <tbody id="tBodyDetalleOC">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End: Modal Detalle Orden de Compras-->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/ConsultarOrdenCompra.js"></script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ReporteMedicamentoStock.aspx.cs" Inherits="SAVM.ReporteVentaStock" %>
<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <h3>Reporte de Medicamentos Proximos a Agotarse</h3>
        <br />
        <div class="form-inline">
            <span class="fa fa-search"></span>
            <input id="txtFiltroMedicamento" type="text" name="name" style="width: 80%" placeholder=" Buscar Medicamento" class="form-control" />

        </div>
        <br>
        <br>

        <div class="col-md-11 panel bg-white-gradient" style="height: 400px; overflow: auto">
            <table id="tblMedicamentos" class=" datatable table table-condensed">
                <thead>
                    <tr>
                        <th>CodMedicamento</th>
                        <th>Medicamento</th>
                        <th>P.Compra</th>
                        <th>P. Venta</th>
                        <th>Stock</th>
                        <th>Stock Mínimo</th>
                        <th>Fec.Vencimiento</th>
                        <th>Tipo Medicamento</th>
                        <th>Proveedor</th>
                    </tr>
                </thead>
                <tbody id="tBodyMedicamentos">
                </tbody>

            </table>
        </div>
        <br>
        <br>
        <div class="col-md-offset-9 col-md-2">
            <input type="button" name="name" class="form-control btn btn-primary" value="Volver" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/ReporteMedicamentosStock.js"></script>
</asp:Content>

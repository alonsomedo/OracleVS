<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ConsultarIncidente.aspx.cs" Inherits="SAVM.ConsultarIncidente" %>
<%@ OutputCache Location="None" NoStore="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <h3>Consultar Incidente de Proveedor</h3>
        <br />
        <div class="form-inline">
            <span class="fa fa-search"></span>
            <input id="txtFiltroIncidentes" type="text" name="name" style="width: 80%" placeholder=" Buscar Incidente" class="form-control" />

        </div>
        <br>
        <br>

        <div class="col-md-11 panel bg-white-gradient table-responsive">
            <table id="tblIncidentes" class=" datatable table table-condensed">
                <thead>
                    <tr>
                        <th>RUC</th>
                        <th>Razón Social</th>
                        <th>Descripción</th>
                        <th>Tipo Incidente</th>
                        <th>Fecha</th>
                    </tr>
                </thead>
                <tbody id="tBodyIncidentes">

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
    <script src="js/ConsultarIncidente.js"></script>
</asp:Content>

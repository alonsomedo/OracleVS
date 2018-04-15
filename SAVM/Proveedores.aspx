<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="SAVM.Proveedores" %>
<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <header class="titulo">
        <div class="container-fluid">
            <h2 style="text-align: left"><strong>Mantener Proveedor</strong></h2>
        </div>
    </header>
    <div class="container-fluid">
        <br>
        <fieldset>
            <legend>Datos del Proveedor</legend>
            <div class="row">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Razón Social:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtRazonSocial" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>RUC:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtRuc" type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Dirección:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtDireccion" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>


                    <div class="row">
                        <div class="col-md-4">
                            <p>Correo Electrónico:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtCorreo" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <p>Nombre Contacto:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtNombreContacto" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Apellido Paterno:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtPaterno" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-md-4">
                            <p>Apellido Materno:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtMaterno" type="text" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>


                    <div class="row">
                        <div class="col-md-4">
                            <p>Teléfono:</p>
                        </div>
                        <div class="col-md-5">
                            <input id="txtTelefono" type="number" name="name" value="" class="form-control" />
                        </div>
                    </div>
                    <br>
                </div>
            </div>
        </fieldset>
        <div class="">
            <input id="btnAgregarProveedor" type="button" class="btn btn-success" value=" ➕ Agregar Proveedor">
        </div>
        <br>

        <div class="row">
            <div class="col-md-11">
                <input type="text" id="txtFiltroProveedor" name="name" value="" placeholder=" 🔍 Ingrese RUC/Razon Social del Proveedor" class="form-control" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-11" style="overflow: auto; height: 300px">
                <table class="table" id="tblProveedores">
                    <thead class="bg-blue-gradient">
                        <tr>
                            <th>RUC</th>
                            <th>Razón Social</th>
                            <th>Dirección</th>
                            <th>Correo electrónico</th>
                            <th>Contacto</th>
                            <th>Teléfono</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="tBodyProveedor">
                    </tbody>
                </table>
            </div>
        </div>
        <br>
        <div class="row">
            <div class="col-md-1">
                <input type="button" class="btn btn-primary" value="Volver">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/Proveedores.js"></script>
</asp:Content>

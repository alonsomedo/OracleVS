<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RegistrarIncidente.aspx.cs" ClientIDMode="Static"
    Inherits="SAVM.RegistrarIncidente" %>
<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content_RI" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <br>
        <div class="row">
            <fieldset>
                <legend>Datos del Proveedor</legend>
                <div class="row">
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-4">
                                <label>Incidentes Registrados:</label>
                            </div>
                            <div class="col-md-5">
                                <input type="number" id="txtNroIncidentes" class="form-control" disabled>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <label>RUC:</label>
                            </div>
                            <div class="col-md-5">
                                <input type="number" class="form-control" id="txtRucProveedor" disabled>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-3">
                                <label>Razón Social:</label>
                            </div>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="txtRazonSocial" disabled>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-3">
                                <label>Contacto:</label>
                            </div>
                            <div class="col-md-6">
                                <input type="text" class="form-control" id="txtContacto" disabled>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-9">
                                <input type="button" data-toggle="modal" data-target="#modalProveedores" id="btnBuscarProveedor" class="form-control btn btn-primary" value="Buscar Proveedor">
                            </div>
                        </div>
                    </div>

                </div>
            </fieldset>
        </div>
        <br>

        <div class="row">
            <fieldset>
                <legend>Datos del Incidente</legend>
                <div class="row">
                    <div class="col-md-8 form-inline">
                        <label>Tipo de Incidente:</label>&nbsp;&nbsp;&nbsp;
					
                        <select  id="ddlTipoIncidencia"class="form-control" style="width: 350px"></select>
                    </div>
                    <div class="form-inline col-md-4">
                        <label for="">Fecha:</label>&nbsp;&nbsp;&nbsp;
					
                        <input id="txtFecha" type="date" class="form-control">
                    </div>
                </div>
                <br>
                <div>
                    <h4>Descripción del Incidente
                    </h4>
                    <textarea id="txtDescIncidente" class="form-control" style="width: 90%">
                    </textarea>
                </div>
            </fieldset>
        </div>
        <br>
        <br>
        <br>

        <div class="row">
            <div class="col-md-1">
                <input type="button" class="btn btn-primary" value="Volver" onclick="location.href = '/Index.aspx'">
            </div>
            <div class="col-md-6">
                <input id="btnRegistrarIncidente" type="button" class="btn btn-success" value="Registrar Incidente">
            </div>
            <br>
            <br>
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


                            <table class="datatable table table-responsive table-bordered table-hover table-striped" id="tblProveedoresIN">
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
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="footer" runat="server">
    <script src="js/RegistrarIncidente.js"></script>
</asp:Content>

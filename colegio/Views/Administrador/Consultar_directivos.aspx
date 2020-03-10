<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Consultar_directivos.aspx.cs" Inherits="colegio.Views.Administrador.Consultar_directivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Area de Directivos<small>Users</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Settings 1</a>
                                </li>
                                <li><a href="#">Settings 2</a>
                                </li>
                            </ul>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>Nombres</th>
                                <th>Apellidos</th>
                                <th>Cargo</th>
                                <th>Edad</th>
                                <th>Fecha de ingreso</th>
                                <th>E-mail</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView runat="server" ID="list_directivos">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("nombres")%></td>
                                        <td><%#Eval("apellidos")%></td>
                                        <td><%#Eval("Nombre")%></td>
                                        <td><%#Eval("edad")%></td>
                                        <td><%#Eval("Fecha")%></td>
                                        <td><%#Eval("correo")%></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>


                </div>
            </div>
        </div>

    </div>




</asp:Content>

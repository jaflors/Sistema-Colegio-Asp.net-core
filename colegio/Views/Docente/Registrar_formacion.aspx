<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Registrar_formacion.aspx.cs" Inherits="colegio.Views.Docente.Registrar_formacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Registrar Formación <small>Session</small></h2>
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
                    <a class="btn btn-primary" data-toggle="modal" data-target="#myModal" >Crear Formación</a>
                    <form runat="server" class="form-horizontal form-label-left">



                        <div class="table-responsive">
                            <table class="table table-striped jambo_table bulk_action">
                                <thead>
                                    <tr class="headings">

                                        <th>Nombres </th>
                                        <th>Apellidos</th>
                                        <th>Titulo</th>
                                        <th>Nivel</th>
                                        <th>Universidad</th>

                                        
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:ListView runat="server" ID="list_info">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("nombres")%> </td>
                                                <td><%#Eval("apellidos")%> </td>
                                                <td><%#Eval("nombre")%> </td>
                                                <td><%#Eval("nombre_titulo")%> </td>
                                                 <td><%#Eval("universidad")%> </td>
                                                

                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </tbody>
                            </table>
                            <!-- Modal -->
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" id="myModalLabel">Registrar Formación</h4>
                                        </div>
                                        <div class="modal-body">
                                            <!-- Modal- body-->
                                            <div class="row">


                                                <div class="col-lg-12">
                                                    <br />
                                                    <div class="panel panel-default">
                                                        <div class="panel-body">

                                                            <div class="row">
                                                                <div class="col-md-6 ">
                                                                    <div class="form-group">
                                                                        <label>Nivel educación *</label>
                                                                        <asp:DropDownList ID="List_nivel" class="form-control" runat="server" required="required"></asp:DropDownList>
                                                                        
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 ">
                                                                    <div class="form-group">
                                                                        <label>Titulo otorgado</label>
                                                                        <asp:TextBox ID="titulo" class="form-control" runat="server" required="required"></asp:TextBox>

                                                                    </div>
                                                                </div>

                                                                <div class="col-md-6 ">
                                                                    <div class="form-group">
                                                                        <label>Universidad</label>

                                                                        <asp:TextBox ID="universidad"  class="form-control" runat="server" required=""></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-6 ">
                                                                    <div class="form-group">
                                                                        <label>Experiencia</label>

                                                                        <asp:DropDownList ID="list_experincia" class="form-control" runat="server" required="required"></asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default"    data-dismiss="modal">Close</button>
                                            <asp:Button ID="guardar" class="btn btn-primary" AutoPostBack="true" runat="server" OnClick="Registrar" Text="Registrar" />

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>








</asp:Content>

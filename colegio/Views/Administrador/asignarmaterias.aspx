<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="asignarmaterias.aspx.cs" Inherits="colegio.Views.Administrador.asignarmaterias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <form runat="server">
                <div class="x_title">
                    <h2>Asignar Materias<small>Users</small></h2>
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

                
                    <div class="row">

                         <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                              <label  for="first-name">Materia<span class="required">*</span></label>
                             </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            
                        <asp:DropDownList ID="List_materias" class="form-control" runat="server" required="required"></asp:DropDownList>
                            
                       </div>
                         <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                              <label  for="first-name">Titulo<span class="required">*</span></label>
                             </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                             <asp:DropDownList ID="list_titulo" class="form-control" runat="server" required="required"></asp:DropDownList>
                        </div>

                        <div class="col-md-1 col-sm-12 col-xs-12 form-group">
                            <label for="first-name">Experiencia<span class="required">*</span></label>
                        </div>
                        <div class="col-md-2 col-sm-12 col-xs-12 form-group">
                            <asp:DropDownList ID="list_experiencia" class="form-control" runat="server" required="required"></asp:DropDownList>
                        </div>

                        <asp:Button ID="Nuevo" CssClass="btn btn-success" EnableViewState="false" runat="server" Text="Consultar" OnClick="Consultar" />



                    </div>

                
                <div class="x_content">

                    <table id="datatable" class="table table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Apellido</th>
                                <th>titulo</th>
                                <th>Acción </th>



                            </tr>
                        </thead>


                        <tbody>

                            <asp:ListView runat="server" ID="list_info">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("nombres")%> </td>
                                        <td><%#Eval("apellidos")%> </td>
                                        <td><%#Eval("nombre")%> </td>
                                        <td>



                                            <asp:LinkButton CommandArgument='<%#Eval("idempleado ")%>' CssClass="btn btn-info btn-xs" OnCommand="asignar_materia" runat="server" CommandName="asignar"><i class="fa fa-pencil"></i>
                                             Asignar</asp:LinkButton>





                                        </td>



                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                   
                        </tbody>
                    </table>
                    
                </div>
                    </form>
            </div>
                    
        </div>
     </div>






</asp:Content>

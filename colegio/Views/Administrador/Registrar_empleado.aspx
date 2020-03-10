<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Registrar_empleado.aspx.cs" Inherits="colegio.Views.Administrador.Registrar_empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Registrar Usuario <small>Session</small></h2>
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
                  <br />
                    <form runat="server" class="form-horizontal form-label-left">

                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Nombres<span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="text" id="Nombres" runat="server" required="required" class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Apellidos<span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="text" id="Apellidos" runat="server" name="last-name" required="required" class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>


                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Edad<span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input type="number" id="Edad" runat="server"  required="required" class="form-control col-md-7 col-xs-12">
                        </div>
                      </div>
                       
                      <div class="form-group">
                        <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">Correo</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="Correo" runat="server" class="form-control col-md-7 col-xs-12" type="email" name="middle-name">
                        </div>
                      </div>

                        <div class="form-group">
                        <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">Contraseña</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="contrsena" runat="server" class="form-control col-md-7 col-xs-12" type="password" name="middle-name">
                        </div>
                      </div>

                      <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">Dependencia</label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <select class="form-control" id="Dependencia" runat="server">
                                    <option>Dependencia option</option>
                                    <option>Administrativos</option>
                                    <option>Docentes</option>
                                    <option>Auxiliar docente </option>
                                     <option>Directivos</option>
                                     <option>Dependencia</option>
                                </select>
                            </div>
                        </div>

                         <div class="form-group">
                        <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">Fecha ingreso</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                          <input id="Fecha_ingreso" runat="server" class="form-control col-md-7 col-xs-12" type="date" name="middle-name">
                        </div>
                      </div>



                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">Rol</label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <select class="form-control" id="Rol" runat="server">
                                    <option>Rol option</option>
                                    <option>Docente</option>
                                    <option>Rector</option>
                                    <option>Coordinador</option>
                                    <option>Secretaria</option>
                                    <option>Auxiliar</option>
                                </select>
                            </div>
                        </div>
                      
                         



                      <div class="form-group">
                          <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                              <button class="btn btn-primary" type="reset">Reset</button>
                              <asp:button id="Button_registrar" runat="server" onclick="Registrar" class="btn btn-success" text="Registrar" />
                          </div>
                      </div>

                        </form>
                </div>

            </div>
        </div>





    </div>





</asp:Content>

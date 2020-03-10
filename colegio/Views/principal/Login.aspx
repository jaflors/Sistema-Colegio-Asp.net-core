<%@ Page Title="" Language="C#" MasterPageFile="~/Views/principal/Principal_Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="colegio.Views.principal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" align="center">
        <div class="h2">Iniciar Sesión</div>
        <br />
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">

                        <form accept-charset="UTF-8" role="form" runat="server" >
                            <fieldset>
                                <div class="form-group">




                                    <input id="Correo" runat="server" type="text"  placeholder="Digite su Correo" class="form-control"  required="required" />
                                </div>
                                <div class="form-group">

                                    <input id="Contrasena" runat="server" type="password" placeholder="Contraseña" class="form-control"  required="required" />

                                </div>
                                
                                <asp:Button ID="Btt_login" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Ingresar" OnClick="Iniciar" />
                                <asp:Label runat="server" ID="princesa"></asp:Label>
                            </fieldset>
                        </form>


                    </div>
                </div>
            </div>
        </div>
        

    </div>





</asp:Content>

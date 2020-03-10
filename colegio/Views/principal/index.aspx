<%@ Page Title="" Language="C#" MasterPageFile="~/Views/principal/Principal_Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="colegio.Views.principal.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
               
                <img src="../../wwwroot/images/banner/IMAGEN%20MI.jpg" />

            </div>

            <div class="item">
                
                <img src="../../wwwroot/images/banner/SAM_0914.jpg" />
            </div>


        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
            <span class="sr-only">Anterior</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
            <span class="sr-only">Siguiente</span>
        </a>
    </div>

    <div class="jumbotron">
        <center>
        <h2>Institución Educativa  San Francisco de Asís</h2>
        <p class="lead">Educación Media Académica Con Intensificación En: Matemáticas, Ciencias Naturales Y Educación Ambiental</p>
        <p><a href="#" class="btn btn-danger">Cotizar &raquo;</a></p>
    </center>
        <div class="row">
            <div class="col-sm-12">

                <div class="row">
                    
                  
                   
                </div>



            </div>
        </div>

    </div>

 
   
</asp:Content>

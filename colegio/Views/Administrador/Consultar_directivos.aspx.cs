using colegio.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace colegio.Views.Administrador
{
    public partial class Consultar_directivos : System.Web.UI.Page
    {
        DataTable dtdirect;
        DataRow drdirect;
        UsuarioController usu = new UsuarioController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                list_directivos.DataSource = usu.Consultar_depencia_diectivos();
                list_directivos.DataBind();

                
             


            }




        }






    }
}
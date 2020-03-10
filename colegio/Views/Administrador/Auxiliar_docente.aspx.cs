using colegio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace colegio.Views.Administrador
{
    public partial class Auxiliar_docente : System.Web.UI.Page
    {
        UsuarioController usu = new UsuarioController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                list_directivos.DataSource = usu.Consultar_dependencia_auxiliares();
                list_directivos.DataBind();





            }
        }
    }
}
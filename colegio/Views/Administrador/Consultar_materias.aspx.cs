using colegio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace colegio.Views.Administrador
{
    public partial class Consultar_materias : System.Web.UI.Page
    {
        MateriaController mate = new MateriaController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                list_info.DataSource = mate.traer_materias_asigadas();
                list_info.DataBind();

            }



        }

    }
}
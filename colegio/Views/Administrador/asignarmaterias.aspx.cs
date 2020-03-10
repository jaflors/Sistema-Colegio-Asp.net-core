using colegio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace colegio.Views.Administrador
{
    public partial class asignarmaterias : System.Web.UI.Page
    {
        MateriaController mate = new MateriaController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                traer_materias();
                traer_titulos();
                traer_experiencia();


            }



        }




        public void traer_materias()
        {
            List_materias.DataSource = mate.traer_id_materia();
            List_materias.DataTextField = "Nombre";
            List_materias.DataValueField = "idMateria";
            List_materias.DataBind();
        }
        public void traer_titulos()
        {
            list_titulo.DataSource = mate.traer_id_titulo();
            list_titulo.DataTextField = "nombre";
            list_titulo.DataValueField = "idTitulo";
            list_titulo.DataBind();
        }

        public void traer_experiencia()
        {
            list_experiencia.DataSource = mate.traer_id_experiencia();
            list_experiencia.DataTextField = "nombre";
            list_experiencia.DataValueField = "idexperiencia";
            list_experiencia.DataBind();
        }


        public void asignar_materia(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("asignar"))
            {
                string idemple = (e.CommandArgument.ToString());

                if (mate.asingnar_materias(List_materias.Text.ToString(),idemple) == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Materia Asignada ');", true);
                    return;

                }

            }


        }


        public void Consultar(object sender, EventArgs e)
        {

            list_info.DataSource = mate.traer_aspirante(list_titulo.Text.ToString(),list_experiencia.Text.ToString()) ;
            list_info.DataBind();



        }
    }
}
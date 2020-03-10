using colegio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace colegio.Views.Docente
{
    public partial class Registrar_formacion : System.Web.UI.Page
    {
        DocenteController obj = new DocenteController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                traer_id_nivel();
                traer_id_experiencia();
                list_info.DataSource = obj.traer_info_docente(Session["login"].ToString());
                list_info.DataBind();

            }




        }


        



        public void traer_id_nivel()
        {
            List_nivel.DataSource = obj.traer_nivel();
            List_nivel.DataTextField = "nombre_titulo";
            List_nivel.DataValueField = "idNivel";
            List_nivel.DataBind();
        }
        public void traer_id_experiencia()
        {
            list_experincia.DataSource = obj.traer_experiencia();
            list_experincia.DataTextField = "nombre";
            list_experincia.DataValueField = "idexperiencia";
            list_experincia.DataBind();
        }


        protected void Registrar(object sender,EventArgs e)
        {
            string id_empleado = obj.traer_id_empleado(Session["login"].ToString());
            DocenteController docentico = new DocenteController(titulo.Text.ToString(),id_empleado,List_nivel.Text.ToString(),list_experincia.Text.ToString(),universidad.Text.ToString());
            if (docentico.inster_formacion(docentico.doce)== true)
            {
                Response.Write("<script> alert('Formación Registrada'); </script>");
                Response.Redirect("~/Views/Docente/Registrar_formacion.aspx");



            }
            else
            {
                Response.Write("<script> alert('Algo salio mal'); </script>");
            }





        }
    }
}
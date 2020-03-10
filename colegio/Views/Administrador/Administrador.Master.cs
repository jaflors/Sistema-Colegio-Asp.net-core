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
    public partial class Administrador : System.Web.UI.MasterPage
    {
        DataTable aux, DatRol;
        DataRow dato, Dr;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["login"] != null)
            {
                MenuController men = new MenuController();
                UsuarioController usu = new UsuarioController();
                men.CargarMenu(Session["login"].ToString(), menugeneral);
                //aux = usu.consultarImg(Session["login"].ToString());
                DatRol = usu.consultarNombreRol(Session["login"].ToString());

                if (DatRol.Rows.Count > 0)
                {
                    Dr = DatRol.Rows[0];
                    Session["Nombre_Rol"] = Dr["Nombre"].ToString();

                }

                //if (aux.Rows.Count > 0)
                //{
                //    dato = aux.Rows[0];
                //    Session["IMG"] = dato["foto"].ToString();

                //}


            }
            else
            {
                Response.Redirect("~/Views/principal/Login.aspx?wsp=1");
            }


        }
    }
}
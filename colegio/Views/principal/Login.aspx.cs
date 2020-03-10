using colegio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace colegio.Views.principal
{
    public partial class Login : System.Web.UI.Page
    {

        Usuario usu = new Usuario();
        DataRow dato;
        DataTable aux;
        string mjs = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            Session.Clear();
            Session["ENTRADA"] = "F";
            if (Session["login"] != null)
            {
                Response.Redirect("~/Views/Administrador/inicio.aspx");
            }
            else
            {
                if (Request.Params["wsp"] != null)
                {
                    String mensaje = Request.Params["wsp"];
                    if (mensaje == "1")
                    {

                        princesa.Text = " Por favor inicia sesión";

                    }
                }


            }



        }




        public void Iniciar(object sender,EventArgs e)
        {

            try
            {
                if (!String.IsNullOrEmpty(Correo.Value.ToString()) && !String.IsNullOrEmpty(Contrasena.Value.ToString()))
                {
                    usu.p_correo = Correo.Value.ToString();
                    usu.p_contrasena = Contrasena.Value.ToString();
                    aux = usu.ConsultarCuenta(usu);
                    if (aux.Rows.Count > 0)
                    {
                        dato = aux.Rows[0];

                        Session["nombre"] = dato["nombres"].ToString() + "  " + dato["apellidos"];
                        Session["login"] = dato["idUsuario"].ToString();
                        Response.Redirect("../Administrador/Inicio.aspx");


                    }
                    else
                    {
                        mjs = "VERIFIQUE SUS DATOS";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                    }

                }
                else
                {
                    mjs = "CAMPOS NO PUEDEN SER VACIOS";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);
                }


            }
            catch (Exception x)
            {


            }






        }
    }
}
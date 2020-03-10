using colegio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace colegio.Views.Administrador
{
    public partial class Registrar_empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void  Registrar (object sender,EventArgs e)
        {

            UsuarioController usu = new UsuarioController(Nombres.Value.ToString(),Apellidos.Value.ToString(),Edad.Value.ToString(),Correo.Value.ToString(), contrsena.Value.ToString());
            string pk_dependencia = (new UsuarioController().ConsultarID_depen(Dependencia.Value.ToString()));
            string pk_Rol = ((new UsuarioController()).ConsultarID_Rol(Rol.Value.ToString()));
            if (usu.inster_usuario(usu.usu,pk_dependencia, Fecha_ingreso.Value.ToString() ,pk_Rol)==true)
            {
                Response.Write("<script> alert('Empleado Registrado '); </script>");
                Nombres.Value = " ";
                Apellidos.Value = " ";
                Edad.Value = " ";
                Correo.Value = " ";
                Dependencia.Value = " ";
                Rol.Value = " ";
               


            }
            else
            {
                Response.Write("<script> alert('Algo salio mal '); </script>");
                return;
            }





        }



    }
}
using colegio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace colegio.Controllers
{
    public class UsuarioController
    {
        public Usuario usu = new Usuario();

        public UsuarioController()
        {
            usu = new Usuario();
        }

        public UsuarioController(string a, string b, string c, string d, string e )
        {
            usu.p_nombre = a;
            usu.p_apellidos = b;
            usu.p_edad = c;
            usu.p_correo = d;
            usu.p_contrasena = e;
          

        }


        public bool inster_usuario(Usuario obj,string a , string b, string c)
        {
            return usu.insertusu(obj, a, b, c);
        }

        //consultas 




        public string ConsultarID_depen(string obj)
        {
            return usu.ConsultarPk(obj);


        }
        public string ConsultarID_Rol(string obj)
        {
            return usu.ConsultarPk_rol(obj);


        }


        public DataTable Consultar_depencia_diectivos()
        {
            return usu.ConsulDirectivos();
        }

        public DataTable Consultar_dependencia_administrativos()
        {
            return usu.ConsulAdministrativos();
        }

        public DataTable Consultar_dependencia_docentes()
        {
            return usu.Consul_docentes();
        }
        public DataTable Consultar_dependencia_auxiliares()
        {
            return usu.Consul_auxiliar_docentes();
        }



        public DataTable consultarNombreRol(string pk_usuario)
        {
            return usu.ConsulNombreRol(pk_usuario);
        }





    }
}
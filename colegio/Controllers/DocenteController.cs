using colegio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace colegio.Controllers
{
    public class DocenteController
    {
        public Docente doce = new Docente();


        public DocenteController()
        {
            doce = new Docente();
        }

        public DocenteController(string a, string b, string c, string d, string e)
        {
            doce.p_nombre_tiltulo = a;
            doce.P_id_empleado = b;
            doce.P_id_nivel = c;
            doce.P_id_experiencia = d;
            doce.p_universidad = e;


        }
        public bool inster_formacion(Docente obj)
        {
            return doce.insertformacion(obj);
        }



        public DataTable traer_nivel()
        {
            return doce.traer_id_nivel();
        }


        public DataTable traer_experiencia()
        {
            return doce.traer_id_experiencia();
        }


        public DataTable traer_info_docente(string id_usu)
        {
            return doce.ConsulInfo_Docente(id_usu);
        }

        public string traer_id_empleado(string id_usu)
        {
            return doce.ConsultarPk_empleado(id_usu);
        }

    }
}
using colegio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace colegio.Controllers
{
    public class MateriaController
    {

        Materia mate = new Materia();


        public DataTable traer_id_materia()
        {
            return mate.traer_id_materias();
        }
        public DataTable traer_id_titulo()
        {
            return mate.traer_id_titulos();
        }
        public DataTable traer_id_experiencia()
        {
            return mate.traer_id_experiencia();
        }

        public DataTable traer_materias_asigadas()
        {
            return mate.consultar_materias_asignadas();
        }
        public DataTable traer_aspirante(string a, string b)
        {
            return mate.consultar_apirante(a,b);
        }

        public bool asingnar_materias(string a , string b)
        {
            return mate.asignar_materias(a,b);
        }


    }
}
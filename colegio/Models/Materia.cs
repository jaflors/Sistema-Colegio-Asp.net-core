using colegio.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace colegio.Models
{
    public class Materia
    {

        BdComun conn = new BdComun();




       


        public bool asignar_materias(string id_materia, string id_empleado)
        {
            Parameter[] para = new Parameter[2];

            para[0] = new Parameter("p_id_materia", id_materia);
            para[1] = new Parameter("p_id_empleado", id_empleado);
          
            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("asignar_materias", para);
            return conn.Transaction(trans);


        }


        public DataTable traer_id_materias()
        {

            string sql = @"select idMateria,Nombre from materia WHERE estado ='A';";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }
        public DataTable traer_id_titulos()
        {

            string sql = @"select idTitulo,nombre from titulo ;";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }




        public DataTable traer_id_experiencia()
        {

            string sql = @"select idexperiencia,nombre from experiencia  ;";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public DataTable consultar_apirante(string id_titulo, string id_experiencia)
        {
            string sql = @"SELECT em.idempleado,  u.nombres,u.apellidos,ti.nombre from usuario as u
            inner JOIN empleado  AS em ON u.idUsuario= em.Usuario_idUsuario
            inner JOIN empleado_titulo AS et ON em.idempleado= et.empleado_idempleado
            INNER JOIN titulo AS ti ON ti.idTitulo=et.Titulo_idTitulo
            INNER JOIN empleado_experiencia AS aex ON em.idempleado= aex.empleado_idempleado
            INNER JOIN experiencia AS ex ON ex.idexperiencia= aex.experiencia_idexperiencia
            WHERE ti.idTitulo='" + id_titulo+"' AND ex.idexperiencia= '"+id_experiencia+"'   ;";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable consultar_materias_asignadas()
        {
            string sql = @" SELECT u.nombres,u.apellidos, mate.Nombre,mate.horas  FROM usuario AS u
            INNER JOIN empleado AS ep ON u.idUsuario=ep.Usuario_idUsuario
            INNER JOIN empleado_materia AS em ON  ep.idempleado=em.empleado_idempleado
            INNER JOIN materia AS mate ON mate.idMateria= em.Materia_idMateria;";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }




    }
}
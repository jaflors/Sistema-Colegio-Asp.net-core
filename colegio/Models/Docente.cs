using colegio.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace colegio.Models
{
    
    public class Docente
    {
        BdComun conn = new BdComun();


        public string p_nombre_tiltulo { get; set; }
        public string P_id_empleado { get; set; }
        public string P_id_nivel { get; set; }

        public string P_id_experiencia { get; set; }
        public string p_universidad { get; set; }



        public bool insertformacion(Docente obj)
        {
            Parameter[] para = new Parameter[5];

            para[0] = new Parameter("p_nombre_tiltulo", obj.p_nombre_tiltulo);
            para[1] = new Parameter("P_id_empleado", obj.P_id_empleado);
            para[2] = new Parameter("P_id_nivel", obj.P_id_nivel);
            para[3] = new Parameter("P_id_experiencia", obj.P_id_experiencia);
            para[4] = new Parameter("p_universidad", obj.p_universidad);
           



            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("insert formacion", para);
            return conn.Transaction(trans);


        }

        public DataTable ConsulInfo_Docente(string id_usuario)
        {
            string sql = @"SELECT u.nombres,u.apellidos,ti.nombre, np.nombre_titulo,et.universidad from usuario as u
            inner JOIN empleado  AS em ON u.idUsuario= em.Usuario_idUsuario
            inner JOIN empleado_titulo AS et ON em.idempleado= et.empleado_idempleado
            INNER JOIN titulo AS ti ON ti.idTitulo=et.Titulo_idTitulo
            INNER JOIN empleado_nivel AS en ON em.idempleado=en.empleado_idempleado
            INNER JOIN nivel_profesional  AS np ON np.idNivel= en.Nivel_profesional_idNivel
				WHERE u.idUsuario='"+id_usuario+"'  ;    ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public DataTable traer_id_nivel()
        {

            string sql = @"select idNivel, nombre_titulo from nivel_profesional;";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }


        public DataTable traer_id_experiencia()
        {

            string sql = @"select idexperiencia,nombre from experiencia;";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public string ConsultarPk_empleado(string obj)
        {
            string sql = @"select idempleado from usuario
            inner join empleado on usuario.idUsuario= empleado.Usuario_idUsuario
            where usuario.idUsuario='"+obj+"';";
            DataTable data = conn.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["idempleado"].ToString();
        }






    }
}
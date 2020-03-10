using colegio.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace colegio.Models
{
    public class Usuario
    {
        BdComun conn = new BdComun();
        public string p_nombre { get; set; }
        public string p_apellidos { get; set; }
        public string p_edad { get; set; }

        public string p_correo { get; set; }
        public string p_contrasena { get; set; }

        public bool insertusu(Usuario obj,string id_dependencia,string fecha_ingreso,string idrol)
        {
            Parameter[] para = new Parameter[8];

            para[0] = new Parameter("p_nombre", obj.p_nombre);
            para[1] = new Parameter("p_apellidos", obj.p_apellidos);
            para[2] = new Parameter("P_edad", obj.p_edad);
            para[3] = new Parameter("p_correo", obj.p_correo);
            para[4] = new Parameter("p_contrasena", obj.p_contrasena);
            para[5] = new Parameter("p_dependencia", id_dependencia);
            para[6] = new Parameter("p_fecha_ingreso", fecha_ingreso);
            para[7] = new Parameter("p_rol", idrol);



            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("insert_usuario", para);
            return conn.Transaction(trans);


        }

        public string ConsultarPk(string obj)
        {
            string sql = "SELECT iddependencia FROM dependencia where dependencia.nombre_dependencia='"+obj+"';";
            DataTable data = conn.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["iddependencia"].ToString();
        }


        public string ConsultarPk_rol(string obj)
        {
            string sql = "SELECT idrol FROM rol where rol.Nombre='"+obj+"';";
            DataTable data = conn.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["idrol"].ToString();
        }



        public DataTable ConsulDirectivos()
        {
            string sql = @"USE colegio;
            SELECT usuario.nombres, usuario.apellidos, rol.Nombre,usuario.edad , DATE_FORMAT(empleado.fecha_ingreso,'%d/%m/%Y') as Fecha, usuario.correo FROM dependencia 
            INNER JOIN empleado_dependencia AS ed ON dependencia.iddependencia= ed.dependencia_iddependencia
            INNER JOIN empleado ON empleado.idempleado= ed.empleado_idempleado
            INNER JOIN usuario ON usuario.idUsuario= empleado.Usuario_idUsuario
            INNER JOIN usuario_rol AS ur ON usuario.idUsuario= ur.Usuario_idUsuario 
            INNER JOIN rol ON rol.idrol= ur.rol_idrol WHERE ed.dependencia_iddependencia=4; ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }
        public DataTable ConsulAdministrativos()
        {
            string sql = @"USE colegio;
            SELECT usuario.nombres, usuario.apellidos, rol.Nombre,usuario.edad , DATE_FORMAT(empleado.fecha_ingreso,'%d/%m/%Y') as Fecha, usuario.correo FROM dependencia 
            INNER JOIN empleado_dependencia AS ed ON dependencia.iddependencia= ed.dependencia_iddependencia
            INNER JOIN empleado ON empleado.idempleado= ed.empleado_idempleado
            INNER JOIN usuario ON usuario.idUsuario= empleado.Usuario_idUsuario
            INNER JOIN usuario_rol AS ur ON usuario.idUsuario= ur.Usuario_idUsuario 
            INNER JOIN rol ON rol.idrol= ur.rol_idrol WHERE ed.dependencia_iddependencia=1; ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public DataTable Consul_docentes()
        {
            string sql = @"USE colegio;
            SELECT usuario.nombres, usuario.apellidos, rol.Nombre,usuario.edad , DATE_FORMAT(empleado.fecha_ingreso,'%d/%m/%Y') as Fecha, usuario.correo FROM dependencia 
            INNER JOIN empleado_dependencia AS ed ON dependencia.iddependencia= ed.dependencia_iddependencia
            INNER JOIN empleado ON empleado.idempleado= ed.empleado_idempleado
            INNER JOIN usuario ON usuario.idUsuario= empleado.Usuario_idUsuario
            INNER JOIN usuario_rol AS ur ON usuario.idUsuario= ur.Usuario_idUsuario 
            INNER JOIN rol ON rol.idrol= ur.rol_idrol WHERE ed.dependencia_iddependencia=2; ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public DataTable Consul_auxiliar_docentes()
        {
            string sql = @"USE colegio;
            SELECT usuario.nombres, usuario.apellidos, rol.Nombre,usuario.edad , DATE_FORMAT(empleado.fecha_ingreso,'%d/%m/%Y') as Fecha, usuario.correo FROM dependencia 
            INNER JOIN empleado_dependencia AS ed ON dependencia.iddependencia= ed.dependencia_iddependencia
            INNER JOIN empleado ON empleado.idempleado= ed.empleado_idempleado
            INNER JOIN usuario ON usuario.idUsuario= empleado.Usuario_idUsuario
            INNER JOIN usuario_rol AS ur ON usuario.idUsuario= ur.Usuario_idUsuario 
            INNER JOIN rol ON rol.idrol= ur.rol_idrol WHERE ed.dependencia_iddependencia=3; ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }



        public DataTable ConsultarCuenta(Usuario obj)
        {

            string sql = "SELECT * FROM usuario WHERE correo='" + obj.p_correo + "'AND contrasena='" + obj.p_contrasena + "' ;";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsulNombreRol(string pk_usuario)
        {
            string sql = @"select Nombre from rol
	        inner join usuario_rol as ur on ur.rol_idRol= rol.idRol
	        inner join usuario on usuario.idusuario= ur.Usuario_idUsuario
	        where  usuario.idusuario= '" + pk_usuario + "';";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable consultarMenu(string idCuenta)
        {
            string sql = @"select menu.`idmenu`,menu.titulo,menu.icono,vista.idvista,vista.nombre,vista.url,vista.icono,vista.menu_idmenu  from menu 
                         inner join vista on menu.`idmenu`=vista.menu_idmenu
                         inner join rol_vista on vista.idVista=rol_vista.vista_idVista
                         inner join rol on rol.idrol=rol_vista.rol_idrol
                         inner join usuario_rol on usuario_rol.rol_idrol=rol.idrol
                         inner join usuario on usuario.idUsuario=usuario_rol.Usuario_idUsuario 
                         where usuario.idUsuario= '" + idCuenta + "';";

            return conn.EjecutarConsulta(sql, CommandType.Text);
        }








    }
}
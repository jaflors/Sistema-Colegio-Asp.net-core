using ColegioApp.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

#nullable disable

namespace ColegioApp.Models
{
    public partial class EstudianteGrado
    {
        public BdComun conn;
        
       
        public int IdEstudianteGrado { get; set; }
        public int FkGrado { get; set; }
        public int FkEstudiante { get; set; }
        public string Año { get; set; }
        

        public virtual Estudiante FkEstudianteNavigation { get; set; }
        public virtual Grado FkGradoNavigation { get; set; }

        public DataTable ConsultarEstudiantes( int IdGrado)
        {
            string sql = @"select AspNetUsers.Nombre,AspNetUsers.Apellido,AspNetUsers.Edad,
            AspNetUsers.identificacion,Estudiante.IdEstudiante,Grado.Nombre as grado
            FROM AspNetUsers
            INNER JOIN Estudiante ON (AspNetUsers.Id=Estudiante.IdUser)
            INNER JOIN EstudianteGrado ON (Estudiante.IdEstudiante= EstudianteGrado.Fk_Estudiante)
            INNER JOIN Grado ON (Grado.IdGrado=EstudianteGrado.Fk_Grado)
            WHERE EstudianteGrado.Fk_Grado= '"+ IdGrado+"' ; ";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable  ConsultarNombreGrado(int IdGrado)
        {
            string sql = @"Select Grado.Nombre
               from Grado where IdGrado='"+IdGrado+ "'; ";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }




    }
}

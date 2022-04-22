using ColegioApp.Datos;
using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace ColegioApp.Models
{
    public partial class Profesor
    {
        public BdComun conn;
        public Profesor()
        {
            MateriaProfesors = new HashSet<MateriaProfesor>();
        }

        public int IdProfesor { get; set; }
        public string IdUser { get; set; }

        public string Especialidad { get; set; }


        public virtual AspNetUser IdUserNavigation { get; set; }
        public virtual ICollection<MateriaProfesor> MateriaProfesors { get; set; }

        public DataTable ConsultarProfes()
        {
            string sql = @"select AspNetUsers.Id as IdUser,AspNetUsers.Nombre,AspNetUsers.Apellido,AspNetUsers.Edad,
            AspNetUsers.identificacion,AspNetUsers.Email ,Profesor.Especialidad
            FROM AspNetUsers
            INNER JOIN Profesor ON (AspNetUsers.Id=Profesor.IdUser);
           ";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable ConsultarIdProfe(string IdUsu)
        {
            string sql = @"Select   Profesor.IdProfesor  From AspNetUsers
             inner join Profesor on  AspNetUsers.Id=Profesor.IdUser
             where AspNetUsers.Id='" + IdUsu + "';";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }


        public DataTable ConsultarEstudiantes(string IdMateria)
        {
            string sql = @"select AspNetUsers.Nombre,AspNetUsers.Apellido, Estudiante.IdEstudiante
            ,Materia.IdMateria
            from AspNetUsers 
            inner join Estudiante on AspNetUsers.Id= Estudiante.IdUser 
            inner join EstudianteGrado on Estudiante.IdEstudiante= EstudianteGrado.Fk_Estudiante
            inner join Grado on Grado.IdGrado=EstudianteGrado.Fk_Grado
            inner join Materia on Grado.IdGrado =Materia.fkGrado
            where Materia.IdMateria='" + IdMateria + "';";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }
    }
}

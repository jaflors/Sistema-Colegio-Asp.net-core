using ColegioApp.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

#nullable disable

namespace ColegioApp.Models
{
    public partial class Estudiante
    {
        public BdComun conn;

        public Estudiante()
        {
            EstudianteGrados = new HashSet<EstudianteGrado>();
            
            Calificacions = new HashSet<Calificacion>();
        }
        [Key]
        public int IdEstudiante { get; set; }
        public string IdUser { get; set; }
     

        public virtual AspNetUser IdUserNavigation { get; set; }
        public virtual ICollection<EstudianteGrado> EstudianteGrados { get; set; }
       
        public virtual ICollection<Calificacion> Calificacions { get; set; }


        public DataTable ConsultarIdEstudiante(string IdUsu)
        {
            string sql = @"Select   Estudiante.IdEstudiante  From AspNetUsers
             inner join Estudiante on  AspNetUsers.Id=Estudiante.IdUser
             where AspNetUsers.Id='" + IdUsu + "';";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable ConsultarMaterias(int IdUsu)
        {
            string sql = @"select Materia.Nombre, Grado.Nombre as Grado, Materia.IdMateria,
concat(AspNetUsers.Nombre,' ', AspNetUsers.Apellido) as Profesor ,Estudiante.IdEstudiante FROM Estudiante
inner join EstudianteGrado on Estudiante.IdEstudiante=EstudianteGrado.Fk_Estudiante
inner join Grado on  Grado.IdGrado= EstudianteGrado.Fk_Grado
inner join Materia on Grado.IdGrado= Materia.fkGrado
inner join MateriaProfesor on Materia.IdMateria=MateriaProfesor.FkMateria
inner join Profesor on Profesor.IdProfesor= MateriaProfesor.Fk_Profesor
inner join AspNetUsers on AspNetUsers.Id= Profesor.IdUser
where Estudiante.IdEstudiante='"+IdUsu+"';";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

    }
}

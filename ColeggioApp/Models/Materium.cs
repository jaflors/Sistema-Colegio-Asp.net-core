using ColegioApp.Datos;
using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace ColegioApp.Models
{
    public partial class Materium
    {
        public BdComun conn;
        public Materium()
        {
           
            MateriaProfesors = new HashSet<MateriaProfesor>();
            Calificacions = new HashSet<Calificacion>();
        }

        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public int? FkGrado { get; set; }

        public virtual Grado FkGradoNavigation { get; set; }
        
        public virtual ICollection<MateriaProfesor> MateriaProfesors { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }

        public DataTable ConsultarMaterias(int IdGrado)
        {
            string sql = @"select Materia.IdMateria, Materia.Nombre as Materia,
            concat(AspNetUsers.Nombre,' ',AspNetUsers.Apellido) as Profesor        
            from Materia
            inner join Grado on Grado.IdGrado= Materia.fkGrado 
            inner join MateriaProfesor on Materia.IdMateria=MateriaProfesor.FkMateria 
            inner join Profesor on Profesor.IdProfesor =MateriaProfesor.Fk_Profesor
            inner join AspNetUsers on AspNetUsers.Id = Profesor.IdUser
            where Grado.IdGrado='" + IdGrado + "'; ";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsultarProfesores()
        {
            string sql = @"select Profesor.IdProfesor, 
            concat(AspNetUsers.Nombre,' ',AspNetUsers.Apellido)as profesor
            from AspNetUsers
            inner join Profesor on AspNetUsers.Id= Profesor.IdUser; ";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }


        }
}

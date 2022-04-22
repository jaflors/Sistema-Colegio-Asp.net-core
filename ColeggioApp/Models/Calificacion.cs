using System;
using System.Collections.Generic;

#nullable disable

namespace ColegioApp.Models
{
    public partial class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int FkEstudiante { get; set; }
        public int FkMateria { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int Nota3 { get; set; }
        public int Definitiva { get; set; }
        public int? FkPeriodo { get; set; }

        public virtual Estudiante FkEstudianteNavigation { get; set; }
        public virtual Materium FkMateriaNavigation { get; set; }
        public virtual Periodo FkPeriodoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ColegioApp.Models
{
    public partial class Grado
    {
        public Grado()
        {
            EstudianteGrados = new HashSet<EstudianteGrado>();
            Materia = new HashSet<Materium>();
        }

        public int IdGrado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<EstudianteGrado> EstudianteGrados { get; set; }
        public virtual ICollection<Materium> Materia { get; set; }
    }
}

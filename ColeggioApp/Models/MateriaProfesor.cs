using System;
using System.Collections.Generic;

#nullable disable

namespace ColegioApp.Models
{
    public partial class MateriaProfesor
    {
        public int FkMateria { get; set; }
        public int FkProfesor { get; set; }

        public virtual Materium FkMateriaNavigation { get; set; }
        public virtual Profesor FkProfesorNavigation { get; set; }
    }
}

using ColegioApp.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

#nullable disable

namespace ColegioApp.Models
{
    public partial class Periodo
    {
        public BdComun conn;
        
        public Periodo()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        public int IdPeriodo { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaFin { get; set; }
        public string Año { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }

      
        public DataTable ConsultarIdPeriodo()
        {
            var fecha = @DateTime.Now.Date.ToString("yyyy-MM-dd");
            string sql = @"select Periodo.IdPeriodo from Periodo
            where '"+fecha+ "' >= Fecha_inicio and '" + fecha + "' <= Fecha_Fin;";

            conn = new();
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }
    }
}

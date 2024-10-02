using System;
using EV2.Models;

namespace EV2.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Estado { get; set; }
        public int Horas { get; set; }
        public string Area { get; set; } 
        public int ProyectoId { get; set; }
        public int EmpleadoAsignado { get; set; }
        public string setHerramienta { get; set; }

    }
}

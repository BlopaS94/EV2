using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practico2PA.DTOs
{
    public class TareaDTO
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Estado de la Tarea, debe ser incorporado obligatoriamente")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Horas de la Tarea, debe ser incorporado obligatoriamente")]
        public int Horas { get; set; }


        [Required(ErrorMessage = "Debe especificar el area de la tarea")]
        public string Area { get; set;}

        [Required(ErrorMessage = "Debe especificar el proyecto al que corresponde la tarea")]
        public int ProyectoId { get; set; }

        [Required(ErrorMessage = "Debe Asignar el empleado")]
        public int EmpleadoAsignadoId { get; set; }


        [Required(ErrorMessage = "Debe Asignar la herramienta")]
        public string SetHerramientas { get; set; }  
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practico2PA.DTOs
{
    public class ProyectoDTO
    {
        public int Id { get; set;}

        [Required(ErrorMessage="Nombre del proyecto, debe ser incorporado obligatoriamente")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Descripción del proyecto, debe ser incorporado obligatoriamente")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Estado del proyecto, debe ser incorporado obligatoriamente")]
        [RegularExpression("Pendiente|En Progreso|Finalizado", ErrorMessage = "El estado debe ser 'Pendiente', 'En progreso' o 'Finalizado'.")]
        public string Estado { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Las horas trabajadas deben ser 0 o más.")]
        public int HorasTrabajadas { get; set; } = 0;

        [Required(ErrorMessage = "Las horas totales son obligatorias.")]
        [Range(1, int.MaxValue, ErrorMessage = "Las horas totales deben ser mayores que 0.")]
        public int HorasTotales { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}

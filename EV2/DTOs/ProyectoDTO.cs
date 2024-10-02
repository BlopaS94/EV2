using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EV2.DTOs
{
    public class ProyectoDTO
    {
        public int Id { get; set;}

        [Required(ErrorMessage="Nombre del proyecto, debe ser incorporado obligatoriamente")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Descripción del proyecto, debe ser incorporado obligatoriamente")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Estado del proyecto, debe ser incorporado obligatoriamente")]
        [RegularExpression("Pendiente|En Progreso|Finalizado", ErrorMessage = "Estado inválido.")]
        public string Estado { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Horas trabajadas no válidas.")]
        public int HorasTrabajadas { get; set; } = 0;

        [Required(ErrorMessage = "Horas totales son obligatorias.")]
        [Range(1, int.MaxValue, ErrorMessage = "Horas totales inválidas.")]
        public int HorasTotales { get; set; }

        [Required(ErrorMessage = "Fecha de creación obligatoria.")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}

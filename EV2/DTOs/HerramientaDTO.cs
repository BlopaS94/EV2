using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practico2PA.DTOs
{
    public class HerramientaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es OBLIGATORIO.")]
        public string Nombre { get; set; }
    }
}

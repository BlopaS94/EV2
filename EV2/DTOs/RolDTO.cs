using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EV2.DTOs
{
    public class RolDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del Rol, debe ser incorporado obligatoriamente")]
        public string Nombre { get; set; }
    }
}


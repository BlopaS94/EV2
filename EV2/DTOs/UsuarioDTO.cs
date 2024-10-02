using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EV2.DTOs
{
    public class UsuarioDTO
    {

        [Required(ErrorMessage = "Nombre del Usuario, debe ser incorporado obligatoriamente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Email del Usuario, debe ser incorporado obligatoriamente")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password del Usuario, debe ser incorporado obligatoriamente")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe incorporar Rol")]
        public int RolId { get; set; }
    }
}
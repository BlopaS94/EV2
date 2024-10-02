using EV2.Responses;
using EV2.Services;
using Microsoft.AspNetCore.Mvc;
using EV2.Data;

namespace Practico2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly RolesService _rolesService;

        public RolesController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<dbContextt>();
            _rolesService = new RolesService(context);
        }

        // Obtener un usuario por su ID
        [HttpGet("mostrarId/{id}")]
        public async Task<ActionResult<RolesResponse>> GetRol(int id)
        {
            var rol = await _rolesService.ObtenerIdRol(id);

            if (rol == null)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Rol no encontrado"
                });
            }

            return Ok(new RolesResponse
            {
                Data = rol,
                Code = 200,
                Message = "Rol obtenido correctamente"
            });
        }
    }
}
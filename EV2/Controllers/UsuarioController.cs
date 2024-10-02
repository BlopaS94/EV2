using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EV2.DTOs;
using EV2.Models;
using EV2.Services;
using EV2.Data;
using EV2.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practico2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<dbContextt>();
            _usuarioService = new UsuarioService(context);
        }

        [HttpGet("mostrarTodo")]
        public async Task<ActionResult<UsuariosResponse>> MostrarUsuarios()
        {
            var usuarios = await _usuarioService.Mostrar();
            return Ok(new UsuariosResponse
            {
                Data = usuarios,
                Code = 200,
                Message = "Funciono"
            });
        }

        [HttpGet("mostrarId/{id}")]
        public async Task<ActionResult<UsuarioResponse>> MostrarIdUsuario(int id)
        {
            var usuario = await _usuarioService.MostrarId(id);

            if (usuario == null)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Usuario no encontrado"
                });
            }

            return Ok(new UsuarioResponse
            {
                Data = usuario,
                Code = 200,
                Message = "Usuario obtenido correctamente"
            });
        }

        [HttpPost("crearUsuarios")]
        public async Task<ActionResult<NuevoUsuarioResponse>> CrearUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            var nuevoUsuario = await _usuarioService.CrearUsuario(usuarioDTO);

            return Ok(new NuevoUsuarioResponse
            {
                Data = true,
                Code = 200,
                Message = "Usuario creado correctamente"
            });
        }

        [HttpPut("actualizarUsuario/{id}")]
        public async Task<ActionResult<UpdateUsuarioResponse>> ActualizarUsuario(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var actualizado = await _usuarioService.ActualizarUsuario(id, usuarioDTO);

            if (!actualizado)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Usuario no encontrado"
                });
            }

            return Ok(new UpdateUsuarioResponse
            {
                Data = true,
                Code = 200,
                Message = "Usuario actualizado correctamente"
            });
        }

        [HttpDelete("eliminarUsuario/{id}")]
        public async Task<ActionResult<DeleteUsuarioResponse>> EliminarUsuario(int id)
        {
            var eliminado = await _usuarioService.EliminarUsuario(id);

            if (!eliminado)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "Usuario no encontrado"
                });
            }

            return Ok(new DeleteUsuarioResponse
            {
                Data = true,
                Code = 200,
                Message = "Usuario eliminado correctamente"
            });
        }
    }
}
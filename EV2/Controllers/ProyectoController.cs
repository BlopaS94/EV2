using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using EV2.DTOs;
using EV2.Models;
using EV2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EV2.Data;

namespace eval2ProgramacionAvanzada.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoService _service;

        public ProyectoController(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<dbContextt>();
            _service = new ProyectoService(dbContext);
        }

        [HttpGet("mostrar")]
        public async Task<ActionResult<List<Proyecto>>> MostrarProyecto()
        {
            var proyectos = await _service.MostrarProyecto();
            return Ok(new
            {
                Data = proyectos,
                Code = 200,
                Message = "Lista de proyectos obtenida con exito."
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> MostrarId(int id)
        {
            var proyecto = await _service.MostrarIdProyecto(id);

            if (proyecto == null)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "No se encontro el proyecto solicitado."
                });
            }

            return Ok(new
            {
                Data = proyecto,
                Code = 200,
                Message = "Proyecto obtenido correctamente."
            });
        }

        [HttpPost]
        public async Task<ActionResult<Proyecto>> CrearProyecto([FromBody] ProyectoDTO proyectoDTO)
        {
            var proyectoCreado = await _service.CrearProyecto(proyectoDTO);

            return CreatedAtAction(nameof(MostrarId), new { id = proyectoCreado.Id }, new
            {
                Data = proyectoCreado,
                Code = 201,
                Message = "Proyecto creado exitosamente."
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProyecto(int id, [FromBody] ProyectoDTO proyectoDTO)
        {
            var fueActualizado = await _service.ActualizarProyecto(id, proyectoDTO);

            if (!fueActualizado)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "El proyecto a modificar no fue encontrado."
                });
            }

            return Ok(new
            {
                Code = 200,
                Message = "Proyecto actualizado correctamente."
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProyecto(int id)
        {
            var fueEliminado = await _service.EliminarProyecto(id);

            if (!fueEliminado)
            {
                return NotFound(new
                {
                    Code = 404,
                    Message = "No se pudo encontrar el proyecto para eliminar."
                });
            }

            return Ok(new
            {
                Code = 200,
                Message = "Proyecto eliminado exitosamente."
            });
        }
    }
}

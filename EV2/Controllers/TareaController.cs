using EV2.Data;
using EV2.DTOs;
using EV2.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EV2.Controllers
{
    public class TareaController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class TareasController : ControllerBase
        {
            private readonly TareaService _tareaService;

            public TareasController(IServiceProvider serviceProvider)
            {
                var context = serviceProvider.GetRequiredService<dbContextt>();
                _tareaService = new TareaService(context);
            }

            [HttpGet("todas")]
            public async Task<ActionResult<TareasResponse>> ObtenerTareas()
            {
                var tareas = await _tareaService.ListaTareas();
                var response = new TareasResponse
                {
                    Data = tareas,
                    Code = 200,
                    Message = "Tareas obtenidas correctamente"
                };

                return Ok(response);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<TareaResponse>> ObtenerTarea(int id)
            {
                var tarea = await _tareaService.ObtenerTarea(id);
                if (tarea == null)
                {
                    return NotFound(new TareaResponse
                    {
                        Code = 404,
                        Message = "Tarea no encontrada"
                    });
                }

                var response = new TareaResponse
                {
                    Data = tarea,
                    Code = 200,
                    Message = "Tarea obtenida correctamente"
                };

                return Ok(response);
            }

            [HttpPost]
            public async Task<ActionResult<NuevaTareaResponse>> CrearTarea([FromBody] TareaDTO tareaDTO)
            {
                var ingreso = await _tareaService.IngresarTarea(tareaDTO);
                if (!ingreso)
                {
                    return BadRequest(new NuevaTareaResponse
                    {
                        Code = 400,
                        Message = "Error al ingresar la tarea"
                    });
                }

                var response = new NuevaTareaResponse
                {
                    Data = true, // O cualquier otra información que desees devolver
                    Code = 201,
                    Message = "Tarea ingresada correctamente"
                };

                return CreatedAtAction(nameof(ObtenerTarea), new { id = tareaDTO.Id }, response);
            }
        }
    }
}

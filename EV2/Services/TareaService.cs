using EV2.Data;
using EV2.DTOs;
using EV2.Models;
using Microsoft.EntityFrameworkCore;

namespace EV2.Services
{
    public class TareaService
    {
        private readonly dbContextt _context;

        public TareaService(dbContextt context)
        {
            _context = context;
        }

        // Obtener todas las tareas
        public async Task<List<Tarea>> ListaTareas()
        {
            return await _context.Tareas.ToListAsync();
        }

        // Obtener una tarea por ID
        public async Task<Tarea?> ObtenerTarea(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        // Crear una nueva tarea
        public async Task<bool> IngresarTarea(TareaDTO tareaDTO)
        {
            var nuevaTarea = new Tarea
            {
                FechaInicio = tareaDTO.FechaInicio,
                Estado = tareaDTO.Estado,
                Horas = tareaDTO.Horas,
                Area = tareaDTO.Area,
                ProyectoId = tareaDTO.ProyectoId,
                EmpleadoAsignado = tareaDTO.EmpleadoAsignadoId,
                setHerramienta = tareaDTO.SetHerramientas
            };

            _context.Tareas.Add(nuevaTarea);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Actualizar una tarea
        public async Task<bool> ActualizarTarea(int id, TareaDTO tareaDTO)
        {
            var tareaExistente = await _context.Tareas.FindAsync(id);
            if (tareaExistente == null)
                return false;

            tareaExistente.FechaInicio = tareaDTO.FechaInicio;
            tareaExistente.Estado = tareaDTO.Estado;
            tareaExistente.Horas = tareaDTO.Horas;
            tareaExistente.Area = tareaDTO.Area;
            tareaExistente.ProyectoId = tareaDTO.ProyectoId;
            tareaExistente.EmpleadoAsignado = tareaDTO.EmpleadoAsignadoId;
            tareaExistente.setHerramienta = tareaDTO.SetHerramientas;

            _context.Tareas.Update(tareaExistente);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar una tarea
        public async Task<bool> EliminarTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return false;

            _context.Tareas.Remove(tarea);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}



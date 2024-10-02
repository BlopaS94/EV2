using Microsoft.EntityFrameworkCore;
using EV2.Models;
using EV2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EV2.Models;
using EV2.Data;

namespace EV2.Services
{
    public class ProyectoService
    {
        private readonly dbContextt _context;

        public ProyectoService(dbContextt context)
        {
            _context = context;
        }

        // Método para crear un nuevo proyecto
        public async Task<Proyecto> CrearProyecto(ProyectoDTO proyectoDTO)
        {
            // Validar el estado
            if (!new[] { "Pendiente", "En progreso", "Finalizado" }.Contains(proyectoDTO.Estado))
            {
                throw new InvalidOperationException("Estado no válido.");
            }

            var nuevoProyecto = new Proyecto
            {
                Nombre = proyectoDTO.Nombre,
                Descripcion = proyectoDTO.Descripcion,
                Estado = "Pendiente",
                HorasTrabajadas = 0,
                HorasTotales = proyectoDTO.HorasTotales,
                FechaCreacion = DateTime.Now
            };

            _context.Proyectos.Add(nuevoProyecto);
            await _context.SaveChangesAsync();

            return nuevoProyecto;
        }

        // Método para obtener todos los proyectos
        public async Task<List<Proyecto>> MostrarProyecto()
        {
            return await _context.Proyectos.ToListAsync();
        }

        // Método para obtener un proyecto por ID
        public async Task<Proyecto> MostrarIdProyecto(int id)
        {
            return await _context.Proyectos.FindAsync(id);
        }

        // Método para actualizar un proyecto
        public async Task<bool> ActualizarProyecto(int id, ProyectoDTO proyectoDTO)
        {
            var proyectoExistente = await _context.Proyectos.FindAsync(id);
            if (proyectoExistente == null) return false;

            // Validar el estado
            if (!new[] { "Pendiente", "En progreso", "Finalizado" }.Contains(proyectoDTO.Estado))
            {
                throw new InvalidOperationException("Estado no válido.");
            }

            proyectoExistente.Nombre = proyectoDTO.Nombre;
            proyectoExistente.Descripcion = proyectoDTO.Descripcion;
            proyectoExistente.HorasTotales = proyectoDTO.HorasTotales;

            await _context.SaveChangesAsync();

            return true;
        }

        // Método para eliminar un proyecto
        public async Task<bool> EliminarProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null) return false;

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


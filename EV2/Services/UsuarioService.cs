using Microsoft.EntityFrameworkCore;
using EV2.Data;
using EV2.Models;
using EV2.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EV2.Services
{
    public class UsuarioService
    {
        private readonly dbContextt _db;

        public UsuarioService(dbContextt db)
        {
            _db = db;
        }

        public async Task<Usuario> CrearUsuario(UsuarioDTO usuarioDTO)
        {
            var rolValido = await _db.Roles.AnyAsync(r => r.Id == usuarioDTO.RolId);
            if (!rolValido) throw new InvalidOperationException("Rol no existe!.");

            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password,
                RolId = usuarioDTO.RolId
            };

            await _db.Usuarios.AddAsync(nuevoUsuario);
            await _db.SaveChangesAsync();

            return nuevoUsuario;
        }

        public async Task<List<Usuario>> Mostrar()
        {
            return await _db.Usuarios.ToListAsync();
        }

        public async Task<Usuario> MostrarId(int id)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> ActualizarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            var usuarioExistente = await _db.Usuarios.FindAsync(id);
            if (usuarioExistente == null) return false;

            var rolValido = await _db.Roles.AnyAsync(r => r.Id == usuarioDTO.RolId);
            if (!rolValido) throw new InvalidOperationException("Rol incorrecto!.");

            usuarioExistente.Nombre = usuarioDTO.Nombre;
            usuarioExistente.Email = usuarioDTO.Email;
            usuarioExistente.Password = usuarioDTO.Password;
            usuarioExistente.RolId = usuarioDTO.RolId;

            _db.Usuarios.Update(usuarioExistente);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var usuario = await _db.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _db.Usuarios.Remove(usuario);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}

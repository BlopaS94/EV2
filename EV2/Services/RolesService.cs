using Microsoft.EntityFrameworkCore;
using EV2.Models;
using EV2.Data;


namespace EV2.Services
{
    public class RolesService
    {
        private readonly dbContextt _dbContext;

        public RolesService(dbContextt dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rol> ObtenerIdRol(int id)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
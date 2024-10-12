using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.Data;
using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressusWebApi.Repositories
{
    public class GrupoMuscularRepository : IGrupoMuscularRepository
    {
        private readonly DataContext _context;

        public GrupoMuscularRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<GrupoMuscular> CreateAsync(GrupoMuscular grupoMuscular)
        {
            _context.GruposMusculares.Add(grupoMuscular);
            await _context.SaveChangesAsync();
            return grupoMuscular;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var grupoMuscular = await _context.GruposMusculares.FindAsync(id);
            if (grupoMuscular == null)
                return false;

            _context.GruposMusculares.Remove(grupoMuscular);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.GruposMusculares.AnyAsync(g => g.Id == id);
        }

        public async Task<GrupoMuscular> GetByIdAsync(int id)
        {
            return await _context.GruposMusculares.FindAsync(id);
        }

        public async Task<GrupoMuscular> GetByNombreAsync(string nombre)
        {
            return await _context.GruposMusculares.FirstOrDefaultAsync(g => g.Nombre == nombre);
        }

        public async Task<List<GrupoMuscular>> GetAllAsync()
        {
            return await _context.GruposMusculares.Include(m => m.MusculosDelGrupo).ToListAsync();
        }
    }
}

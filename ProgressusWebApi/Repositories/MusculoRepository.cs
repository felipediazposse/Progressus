using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.Data;
using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;

namespace ProgressusWebApi.Repositories
{
    public class MusculoRepository : IMusculoRepository
    {
        private readonly DataContext _context;

        public MusculoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Musculo> CreateAsync(Musculo musculo)
        {
                _context.Musculos.Add(musculo);
                await _context.SaveChangesAsync();
                return musculo;
        }

        public async Task<Musculo?> DeleteAsync(int id)
        {
            var musculo = await _context.Musculos.FindAsync(id);
            if (musculo == null)
            {
                return null;
            }

            _context.Musculos.Remove(musculo);
            await _context.SaveChangesAsync();
            return musculo;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Musculos.AnyAsync(m => m.Id == id);
        }

        public async Task<Musculo?> GetByIdAsync(int id)
        {
            return await _context.Musculos
                .Include(m => m.GrupoMuscular)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Musculo?> GetByNameAsync(string nombre)
        {
            return await _context.Musculos
                .Include(m => m.GrupoMuscular)
                .FirstOrDefaultAsync(m => m.Nombre == nombre);
        }

        public async Task<List<Musculo>> GetAllAsync()
        {
            return await _context.Musculos
                .Include(m => m.GrupoMuscular)
                .ToListAsync();
  
        }

        public async Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId)
        {
            return await _context.Musculos
                .Where(m => m.GrupoMuscularId == grupoMuscularId)
                .Include(m => m.GrupoMuscular)
                .ToListAsync();
        }
    }
}
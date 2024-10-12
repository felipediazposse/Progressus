using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.Data;
using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;

namespace ProgressusWebApi.Repositories
{
    public class MusculoDeEjercicioRepository : IMusculoDeEjercicioRepository
    {
        private readonly DataContext _context;

        public MusculoDeEjercicioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<MusculoDeEjercicio> CreateAsync(MusculoDeEjercicio musculoDeEjercicio)
        {
            _context.MusculosDeEjercicio.Add(musculoDeEjercicio);
            await _context.SaveChangesAsync();
            return musculoDeEjercicio;
        }

        public async Task<MusculoDeEjercicio?> GetByIdAsync(int ejercicioId, int musculoId)
        {
            return await _context.MusculosDeEjercicio
                                 .FirstOrDefaultAsync(m => m.EjercicioId == ejercicioId && m.MusculoId == musculoId);
        }

        public async Task<List<MusculoDeEjercicio>> GetAllAsync()
        {
            return await _context.MusculosDeEjercicio
                                 .Include(m => m.Ejercicio)
                                 .Include(m => m.Musculo)
                                 .ToListAsync();
        }

        public async Task<MusculoDeEjercicio?> UpdateAsync(int ejercicioId, int musculoId, MusculoDeEjercicio musculoDeEjercicio)
        {
            var existingMusculoDeEjercicio = await _context.MusculosDeEjercicio
                                                           .FirstOrDefaultAsync(m => m.EjercicioId == ejercicioId && m.MusculoId == musculoId);
            if (existingMusculoDeEjercicio == null) return null;

            existingMusculoDeEjercicio.EjercicioId = musculoDeEjercicio.EjercicioId;
            existingMusculoDeEjercicio.MusculoId = musculoDeEjercicio.MusculoId;

            await _context.SaveChangesAsync();
            return existingMusculoDeEjercicio;
        }

        public async Task<MusculoDeEjercicio?> DeleteAsync(int ejercicioId, int musculoId)
        {
            var musculoDeEjercicio = await _context.MusculosDeEjercicio
                                                   .FirstOrDefaultAsync(m => m.EjercicioId == ejercicioId && m.MusculoId == musculoId);
            if (musculoDeEjercicio == null) return null;

            _context.MusculosDeEjercicio.Remove(musculoDeEjercicio);
            await _context.SaveChangesAsync();
            return musculoDeEjercicio;
        }
    }
}

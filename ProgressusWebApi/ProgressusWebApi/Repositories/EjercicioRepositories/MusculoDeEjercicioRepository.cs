using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.DataContext;
using ProgressusWebApi.Models.EjercicioModels;
using ProgressusWebApi.Repositories.EjercicioRepositories.Interfaces;

namespace ProgressusWebApi.Repositories.EjercicioRepositories
{
    public class MusculoDeEjercicioRepository : IMusculoDeEjercicioRepository
    {
        private readonly ProgressusDataContext _context;

        public MusculoDeEjercicioRepository(ProgressusDataContext context)
        {
            _context = context;
        }
        public async Task<List<MusculoDeEjercicio>> ObtenerMusculosDeEjercicio(int ejercicioId)
        {
            return await _context.Set<MusculoDeEjercicio>()
                                 .Include(mde => mde.Musculo)
                                 .Where(mde => mde.EjercicioId == ejercicioId)
                                 .ToListAsync();
        }

        public async Task<MusculoDeEjercicio?> AgregarMusculoAEjercicio(MusculoDeEjercicio musculoDeEjercicio)
        {
            _context.Set<MusculoDeEjercicio>().Add(musculoDeEjercicio);
            await _context.SaveChangesAsync();

            return musculoDeEjercicio;
        }

        public async Task<MusculoDeEjercicio?> QuitarMusculoAEjercicio(MusculoDeEjercicio musculoDeEjercicio)
        {
            var musculoExiste = await _context.Set<MusculoDeEjercicio>()
                                                   .FirstOrDefaultAsync(mde => mde.EjercicioId == musculoDeEjercicio.EjercicioId && mde.MusculoId == musculoDeEjercicio.MusculoId);

            if (musculoExiste != null)
            {
                _context.Set<MusculoDeEjercicio>().Remove(musculoDeEjercicio);
                await _context.SaveChangesAsync();
            }

            return musculoDeEjercicio;
        }

    }
}

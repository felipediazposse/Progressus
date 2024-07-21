using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.DataContext;
using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;

namespace ProgressusWebApi.Repositories.PlanEntrenamientoRepositories
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

        public async Task<MusculoDeEjercicio?> AgregarMusculoAEjercicio(int ejercicioId, int musculoId)
        {
            var musculoDeEjercicio = new MusculoDeEjercicio
            {
                EjercicioId = ejercicioId,
                MusculoId = musculoId
            };

            _context.Set<MusculoDeEjercicio>().Add(musculoDeEjercicio);
            await _context.SaveChangesAsync();

            return musculoDeEjercicio;
        }

        public async Task<MusculoDeEjercicio?> QuitarMusculoAEjercicio(int ejercicioId, int musculoId)
        {
            var musculoDeEjercicio = await _context.Set<MusculoDeEjercicio>()
                                                   .FirstOrDefaultAsync(mde => mde.EjercicioId == ejercicioId && mde.MusculoId == musculoId);

            if (musculoDeEjercicio != null)
            {
                _context.Set<MusculoDeEjercicio>().Remove(musculoDeEjercicio);
                await _context.SaveChangesAsync();
            }

            return musculoDeEjercicio;
        }

    }
}

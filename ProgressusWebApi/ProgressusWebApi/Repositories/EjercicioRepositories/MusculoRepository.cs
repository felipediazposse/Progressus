using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.DataContext;
using ProgressusWebApi.Models.EjercicioModels;
using ProgressusWebApi.Repositories.EjercicioRepositories.Interfaces;

namespace ProgressusWebApi.Repositories.EjercicioRepositories
{
    public class MusculoRepository : IMusculoRepository
    {
        private readonly ProgressusDataContext _context;

        public MusculoRepository(ProgressusDataContext context)
        {
            _context = context;
        }

        public async Task<bool> ComprobarExistencia(int id)
        {
            return await _context.Musculos.AnyAsync(m => m.Id == id);
        }

        public async Task<Musculo> Crear(Musculo musculo)
        {
            _context.Musculos.Add(musculo);
            await _context.SaveChangesAsync();
            return musculo;
        }

        public async Task<Musculo?> Eliminar(int id)
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

        public async Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId)
        {
            return await _context.Musculos
            .Where(m => m.GrupoMuscularId == grupoMuscularId)
            .Include(m => m.GrupoMuscular)
            .ToListAsync();
        }

        public async Task<Musculo?> ObtenerPorId(int id)
        {
            return await _context.Musculos
              .Include(m => m.GrupoMuscular)
              .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Musculo?> ObtenerPorNombre(string nombre)
        {
            return await _context.Musculos
                .Include(m => m.GrupoMuscular)
                .FirstOrDefaultAsync(m => m.Nombre == nombre);
        }

        public async Task<List<Musculo>> ObtenerTodos()
        {
            return await _context.Musculos
                .Include(m => m.GrupoMuscular)
                .ToListAsync();
        }
    }
}

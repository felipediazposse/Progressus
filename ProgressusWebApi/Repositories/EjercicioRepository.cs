using Microsoft.EntityFrameworkCore;
using ProgressusWebApi.Data;
using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories.Interfaces;

namespace ProgressusWebApi.Repositories
{
    public class EjercicioRepository : IEjercicioRepository
    {
        private readonly DataContext _context;

        public EjercicioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Ejercicio> CreateAsync(Ejercicio ejercicio)
        {
            _context.Ejercicios.Add(ejercicio);
            await _context.SaveChangesAsync();
            return ejercicio;
        }

        public async Task<Ejercicio?> GetByIdAsync(int id)
        {
            return await _context.Ejercicios.Include(e => e.MusculosDeEjercicio)
                                             .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Ejercicio>> GetAllAsync()
        {
            return await _context.Ejercicios.Include(e => e.MusculosDeEjercicio)
                                             .ToListAsync();
        }

        public async Task<Ejercicio?> UpdateAsync(int id, Ejercicio ejercicio)
        {
            var existingEjercicio = await _context.Ejercicios.FindAsync(id);
            if (existingEjercicio == null) return null;

            existingEjercicio.Nombre = ejercicio.Nombre;
            existingEjercicio.Descripcion = ejercicio.Descripcion;
            existingEjercicio.ImagenMaquina = ejercicio.ImagenMaquina;
            existingEjercicio.VideoEjercicio = ejercicio.VideoEjercicio;

            await _context.SaveChangesAsync();
            return existingEjercicio;
        }

        public async Task<Ejercicio?> DeleteAsync(int id)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio == null) return null;

            _context.Ejercicios.Remove(ejercicio);
            await _context.SaveChangesAsync();
            return ejercicio;
        }
    }
}

using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IEjercicioRepository
    {
        Task<Ejercicio> CreateAsync(Ejercicio ejercicio);
        Task<Ejercicio?> GetByIdAsync(int id);
        Task<List<Ejercicio>> GetAllAsync();
        Task<Ejercicio?> UpdateAsync(int id, Ejercicio ejercicio);
        Task<Ejercicio?> DeleteAsync(int id);
    }
}

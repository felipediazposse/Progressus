using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IMusculoDeEjercicioRepository
    {
        Task<MusculoDeEjercicio> CreateAsync(MusculoDeEjercicio musculoDeEjercicio);
        Task<MusculoDeEjercicio?> GetByIdAsync(int ejercicioId, int musculoId);
        Task<List<MusculoDeEjercicio>> GetAllAsync();
        Task<MusculoDeEjercicio?> UpdateAsync(int ejercicioId, int musculoId, MusculoDeEjercicio musculoDeEjercicio);
        Task<MusculoDeEjercicio?> DeleteAsync(int ejercicioId, int musculoId);
    }
}

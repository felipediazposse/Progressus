using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IMusculoDeEjercicioRepository
    {
        Task<List<MusculoDeEjercicio>> ObtenerMusculosDeEjercicio(int ejercicioId);
        Task<MusculoDeEjercicio?> AgregarMusculoAEjercicio(int ejercicioId, int musculoId);
        Task<MusculoDeEjercicio?> QuitarMusculoAEjercicio(int ejercicioId, int musculoId);
    }
}

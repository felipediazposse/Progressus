using ProgressusWebApi.Models.EjercicioModels;

namespace ProgressusWebApi.Repositories.EjercicioRepositories.Interfaces
{
    public interface IMusculoDeEjercicioRepository
    {
        Task<List<MusculoDeEjercicio>> ObtenerMusculosDeEjercicio(int ejercicioId);
        Task<MusculoDeEjercicio?> AgregarMusculoAEjercicio(MusculoDeEjercicio musculoDeEjercicio);
        Task<MusculoDeEjercicio?> QuitarMusculoAEjercicio(MusculoDeEjercicio musculoDeEjercicio);
    }
}

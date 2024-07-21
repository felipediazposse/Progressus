using ProgressusWebApi.Model;

namespace ProgressusWebApi.Services.Interfaces
{
    public interface IMusculoDeEjercicioService
    {
        Task<MusculoDeEjercicio> Crear(MusculoDeEjercicio musculoDeEjercicio);
        Task<MusculoDeEjercicio?> ObtenerPorId(int ejercicioId, int musculoId);
        Task<List<MusculoDeEjercicio>> ObtenerTodos();
        Task<MusculoDeEjercicio?> Actualizar(int ejercicioId, int musculoId, MusculoDeEjercicio musculoDeEjercicio);
        Task<MusculoDeEjercicio?> Eliminar(int ejercicioId, int musculoId);
    }
}

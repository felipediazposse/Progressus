using ProgressusWebApi.Model;

namespace ProgressusWebApi.Services.Interfaces
{
    public interface IEjercicioService
    {
        Task<Ejercicio> Crear(Ejercicio ejercicio);
        Task<Ejercicio?> ObtenerPorId(int id);
        Task<List<Ejercicio>> ObtenerTodos();
        Task<List<Ejercicio>> ObtenerPorGrupoMuscular(int grupoMuscularId);
        Task<List<Ejercicio>> ObtenerPorMusculo(int musculoId);
        Task<Ejercicio?> Actualizar(int id, Ejercicio ejercicio);
        Task<Ejercicio?> Eliminar(int id);
    }
}

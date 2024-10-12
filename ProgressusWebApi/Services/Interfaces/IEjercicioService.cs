using ProgressusWebApi.Model;

namespace ProgressusWebApi.Services.Interfaces
{
    public interface IEjercicioService
    {
        Task<Ejercicio> Crear(Ejercicio ejercicio);
        Task<Ejercicio?> ObtenerPorId(int id);
        Task<List<Ejercicio>> ObtenerTodos();
        Task<List<Ejercicio>> ObtenerPorGrupoMuscular();
        Task<Ejercicio?> Actualizar(int id, Ejercicio ejercicio);
        Task<Ejercicio?> Eliminar(int id);
    }
}

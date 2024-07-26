using ProgressusWebApi.Models.EjercicioModels;

namespace ProgressusWebApi.Services.EjercicioServices.Interfaces
{
    public interface IMusculoService
    {
        Task<Musculo> Crear(Musculo musculo);
        Task<Musculo?> Eliminar(int id);
        Task<Musculo?> ObtenerPorId(int id);
        Task<Musculo?> ObtenerPorNombre(string nombre);
        Task<List<Musculo>> ObtenerTodos();
        Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId);
    }
}

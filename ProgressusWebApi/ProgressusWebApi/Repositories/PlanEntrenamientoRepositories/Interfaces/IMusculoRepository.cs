using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IMusculoRepository
    {
        Task<Musculo> Crear(Musculo musculo);
        Task<Musculo?> Eliminar(int id);
        Task<bool> ComprobarExistencia(int id);
        Task<Musculo?> ObtenerPorId(int id);
        Task<Musculo?> ObtenerPorNombre(string nombre);
        Task<List<Musculo>> ObtenerTodos();
        Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId);
    }
}

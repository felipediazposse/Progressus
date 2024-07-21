using ProgressusWebApi.Model;

namespace ProgressusWebApi.Services.Interfaces
{
    public interface IGrupoMuscularService
    {
        Task<GrupoMuscular> Crear(GrupoMuscular grupoMuscular);
        Task<bool> Eliminar(int id);

        Task<GrupoMuscular> Actualizar(int id, GrupoMuscular grupoMuscular);
        Task<GrupoMuscular> ObtenerPorId(int id);
        Task<List<GrupoMuscular>> ObtenerPorNombre(string nombre);
        Task<List<GrupoMuscular>> ObtenerTodos();
    }
}

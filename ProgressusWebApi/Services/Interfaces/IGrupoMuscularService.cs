using ProgressusWebApi.Dtos.GrupoMuscularDto;
using ProgressusWebApi.Model;

namespace ProgressusWebApi.Services.Interfaces
{
    public interface IGrupoMuscularService
    {
        Task<GrupoMuscular> Crear(CrearGrupoMuscularDto grupoMuscularDto);
        Task<bool> Eliminar(int id);
        Task<bool> ComprobarExistencia(int id);
        Task<GrupoMuscular> ObtenerPorId(int id);
        Task<GrupoMuscular> ObtenerPorNombre(string nombre);
        Task<List<GrupoMuscular>> ObtenerTodos();
    }
}

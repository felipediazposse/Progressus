using ProgressusWebApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IGrupoMuscularRepository
    {
        Task<GrupoMuscular> Crear(GrupoMuscular grupoMuscular);
        Task<bool> Eliminar(int id);
        Task<bool> ComprobarExistencia(int id);
        Task<GrupoMuscular> ObtenerPorId(int id);
        Task<List<GrupoMuscular>> ObtenerPorNombre(string nombre);
        Task<List<GrupoMuscular>> ObtenerTodos();
        Task<GrupoMuscular?> Actualizar(int id, GrupoMuscular grupoMuscular);
    }
}

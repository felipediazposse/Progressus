using ProgressusWebApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IGrupoMuscularRepository
    {
        Task<GrupoMuscular> CreateAsync(GrupoMuscular grupoMuscular);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<GrupoMuscular> GetByIdAsync(int id);
        Task<GrupoMuscular> GetByNombreAsync(string nombre);
        Task<List<GrupoMuscular>> GetAllAsync();
    }
}

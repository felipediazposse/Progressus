using ProgressusWebApi.Dtos.MusculoDto;
using ProgressusWebApi.Model;

namespace ProgressusWebApi.Repositories.Interfaces
{
    public interface IMusculoRepository
    {
        Task<Musculo> CreateAsync(Musculo musculo);
        Task<Musculo?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<Musculo?> GetByIdAsync(int id);
        Task<Musculo?> GetByNameAsync(string nombre);
        Task<List<Musculo>> GetAllAsync();

        Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId);
    }
}

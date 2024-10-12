using ProgressusWebApi.Dtos.MusculoDto;
using ProgressusWebApi.Model;
using static ProgressusWebApi.Dtos.MusculoDto.ObtenerMusculoDto;

namespace ProgressusWebApi.Services.Interfaces
{
    public interface IMusculoService
    {
        Task<Musculo> Crear(CrearMusculoDto musculoDto);
        Task<Musculo?> Eliminar(int id);
        Task<bool> ComprobarExistencia(int id);
        Task<Musculo?> ObtenerPorId(int id);
        Task<Musculo?> ObtenerPorNombre(string nombre);
        Task<List<Musculo>> ObtenerTodos();
        Task<List<Musculo>> ObtenerPorGrupoMuscular(int grupoMuscularId);
    }
}

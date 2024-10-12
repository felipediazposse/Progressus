using AutoMapper;
using ProgressusWebApi.Dtos.GrupoMuscularDto;
using ProgressusWebApi.Dtos.MusculoDto;
using ProgressusWebApi.Model;
namespace ProgressusWebApi.Mappers
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<CrearGrupoMuscularDto, GrupoMuscular>();
            CreateMap<Musculo, ObtenerMusculoDto>();   
        }
    }
}
 
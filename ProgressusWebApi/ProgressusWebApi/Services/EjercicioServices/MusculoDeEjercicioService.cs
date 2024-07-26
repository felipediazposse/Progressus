using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.EjercicioDtos.EjercicioDto;
using ProgressusWebApi.Models.EjercicioModels;
using ProgressusWebApi.Repositories.EjercicioRepositories.Interfaces;
using ProgressusWebApi.Services.EjercicioServices.Interfaces;

namespace ProgressusWebApi.Services.EjercicioServices
{
    public class MusculoDeEjercicioService : IMusculoDeEjercicioService
    {
        private readonly IMusculoDeEjercicioRepository _musculoDeEjercicioRepository;
        public MusculoDeEjercicioService(IMusculoDeEjercicioRepository musculoDeEjercicioRepository)
        {
            _musculoDeEjercicioRepository = musculoDeEjercicioRepository;
        }

        public async Task<IActionResult> AgregarMusculoAEjercicio(AgregarQuitarMusculoAEjercicioDto agregarQuitarMusculoAEjercicioDto)
        {
            List<MusculoDeEjercicio> musculosAgregados = new List<MusculoDeEjercicio>();
            for (int i = 0; i < agregarQuitarMusculoAEjercicioDto.MusculosIds.Count; i++)
            {
                MusculoDeEjercicio musculoDeEjercicio = new MusculoDeEjercicio()
                {
                    MusculoId = agregarQuitarMusculoAEjercicioDto.MusculosIds[i],
                    EjercicioId = agregarQuitarMusculoAEjercicioDto.EjercicioId,
                };
                await _musculoDeEjercicioRepository.AgregarMusculoAEjercicio(musculoDeEjercicio);
                musculosAgregados.Add(musculoDeEjercicio);
            }
            return new OkObjectResult(musculosAgregados);
        }

        public async Task<IActionResult> QuitarMusculoAEjercicio(AgregarQuitarMusculoAEjercicioDto agregarQuitarMusculoAEjercicioDto)
        {
            List<MusculoDeEjercicio> musculosQuitados = new List<MusculoDeEjercicio>();
            for (int i = 0; i < agregarQuitarMusculoAEjercicioDto.MusculosIds.Count; i++)
            {
                MusculoDeEjercicio musculoDeEjercicio = new MusculoDeEjercicio()
                {
                    MusculoId = agregarQuitarMusculoAEjercicioDto.MusculosIds[i],
                    EjercicioId = agregarQuitarMusculoAEjercicioDto.EjercicioId,
                };
                await _musculoDeEjercicioRepository.QuitarMusculoAEjercicio(musculoDeEjercicio);
                musculosQuitados.Add(musculoDeEjercicio);
            }
            return new OkObjectResult(musculosQuitados);
        }
    }
}

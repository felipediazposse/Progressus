using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services
{
    public class MusculoDeEjercicioService : IMusculoDeEjercicioService
    {
        private readonly IMusculoDeEjercicioRepository _repository;

        public MusculoDeEjercicioService(IMusculoDeEjercicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<MusculoDeEjercicio> CreateAsync(MusculoDeEjercicio musculoDeEjercicio)
        {
            return await _repository.CreateAsync(musculoDeEjercicio);
        }

        public async Task<MusculoDeEjercicio?> GetByIdAsync(int ejercicioId, int musculoId)
        {
            return await _repository.GetByIdAsync(ejercicioId, musculoId);
        }

        public async Task<List<MusculoDeEjercicio>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MusculoDeEjercicio?> UpdateAsync(int ejercicioId, int musculoId, MusculoDeEjercicio musculoDeEjercicio)
        {
            return await _repository.UpdateAsync(ejercicioId, musculoId, musculoDeEjercicio);
        }

        public async Task<MusculoDeEjercicio?> DeleteAsync(int ejercicioId, int musculoId)
        {
            return await _repository.DeleteAsync(ejercicioId, musculoId);
        }
    }

}

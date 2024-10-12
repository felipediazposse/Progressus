using ProgressusWebApi.Model;
using ProgressusWebApi.Repositories;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services.Interfaces;

namespace ProgressusWebApi.Services
{
    public class EjercicioService : IEjercicioService
    {
        private readonly IEjercicioRepository _repository;

        public EjercicioService(IEjercicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ejercicio> CreateAsync(Ejercicio ejercicio)
        {
            return await _repository.CreateAsync(ejercicio);
        }

        public async Task<Ejercicio?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Ejercicio>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Ejercicio?> UpdateAsync(int id, Ejercicio ejercicio)
        {
            return await _repository.UpdateAsync(id, ejercicio);
        }

        public async Task<Ejercicio?> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

}

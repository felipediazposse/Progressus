using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;

namespace ProgressusWebApi.Services.CobroServices.Interfaces
{
    public interface IMercadoPagoService
    {
        Task<Preference> CreatePreferenceAsync(PreferenceRequest preference);
    }
}

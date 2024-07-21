using MercadoPago.Client.Preference;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMercadoPago.Services.Interface;

namespace ProgressusWebApi.Controllers.CobroControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoPagoController : ControllerBase
    {
        private readonly IMercadoPagoService _mercadoPagoService;

        public MercadoPagoController(IMercadoPagoService mercadoPagoService)
        {
            _mercadoPagoService = mercadoPagoService;
        }

        // En el front se debe redirigir al usuario a la URL del campo "init-point"
        [HttpPost("CrearSolicitudDePago")]
        public async Task<IActionResult> CreatePreferenceAsync([FromBody] PreferenceRequest preference)
        {
            try
            {
                var result = await _mercadoPagoService.CreatePreferenceAsync(preference);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Data;
using ProgressusWebApi.Repositories.Interfaces;

namespace ProgressusWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanDeEntrenamientoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPlanDeEntrenamientoRepository _planRepository;
        private readonly IEmailSender _emailSender;
        public PlanDeEntrenamientoController(DataContext context)
        {
            _context = context;
        }

       



    }
}

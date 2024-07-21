using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressusWebApi.Dtos.EmailDtos;
using ProgressusWebApi.Services.EmailServices.Interfaces;

namespace ProgressusWebApi.Controllers.EmailControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailSenderService _emailSenderService;

        public EmailSenderController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        [HttpPost("sendEmail")]
        public void SendEmail(SendEmailDto request)
        {
            _emailSenderService.SendEmail(request.Subject, request.Body, request.To);
        }

    }
}

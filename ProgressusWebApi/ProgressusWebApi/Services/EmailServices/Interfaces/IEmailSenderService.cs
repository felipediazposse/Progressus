namespace ProgressusWebApi.Services.EmailServices.Interfaces
{
    public interface IEmailSenderService
    {
        void SendEmail(string subject, string body, string to);
    }
}

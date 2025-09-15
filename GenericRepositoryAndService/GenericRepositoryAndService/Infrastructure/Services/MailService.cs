using GenericRepositoryAndService.ApplicationCore.Abstractions.Services;

namespace GenericRepositoryAndService.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}

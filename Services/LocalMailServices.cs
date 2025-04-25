namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo;
        private readonly string _mailFrom;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["Logging:mailSettings:mailToAddress"] ?? throw new ArgumentNullException(nameof(configuration));
            _mailFrom = configuration["Logging:mailSettings:mailFromAddress"] ?? throw new ArgumentNullException(nameof(configuration));
        }
        
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with {nameof(LocalMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
namespace StudentTracker.Data
{
    public class ConfigurationManagerService
    {
        private readonly IConfiguration _configuration;
        private const string USERNAME = "Credentials:Username";
        private const string PASSWORD = "Credentials:Password";


        public ConfigurationManagerService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }

        public string GetUsername() => _configuration[USERNAME]!;
        public string GetPassword() => _configuration[PASSWORD]!;

    }
}

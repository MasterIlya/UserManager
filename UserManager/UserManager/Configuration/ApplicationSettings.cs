using Microsoft.Extensions.Configuration;

namespace UserManager.Configuration
{
    public class ApplicationSettings
    {
        public string ConnectionString { get; set; }

        public void Init(IConfiguration configuration)
        {
            ConnectionString = configuration[nameof(ConnectionString)];
        }
    }
}


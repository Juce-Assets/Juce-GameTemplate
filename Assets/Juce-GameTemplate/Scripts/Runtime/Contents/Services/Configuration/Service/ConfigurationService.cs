using Template.Contents.Services.General.Configuration;

namespace Template.Contents.Services.Configuration.Service
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly GameConfiguration gameConfiguration;

        public ConfigurationService(
            GameConfiguration gameConfiguration
            )
        {
            this.gameConfiguration = gameConfiguration;
        }
    }
}
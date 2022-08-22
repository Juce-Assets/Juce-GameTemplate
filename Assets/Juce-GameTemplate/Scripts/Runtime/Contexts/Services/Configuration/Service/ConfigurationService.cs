using Template.Contexts.Shared.Configuration;

namespace Template.Contexts.Services.Configuration.Service
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
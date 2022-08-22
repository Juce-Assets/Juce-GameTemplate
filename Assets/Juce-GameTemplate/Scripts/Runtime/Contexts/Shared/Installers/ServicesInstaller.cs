using Juce.Core.Di.Builder;
using Juce.CoreUnity.Di.Extensions;
using Juce.CoreUnity.Tick.Services;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contexts.Services.Configuration.Service;
using Template.Contexts.Services.Persistence.Service;

namespace Template.Contents.Shared.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDiContainerBuilder container)
        {
            container.Bind<ITickablesService>().FromServicesLocator();
            container.Bind<IUiViewStackService>().FromServicesLocator();
            container.Bind<IConfigurationService>().FromServicesLocator();
            container.Bind<IPersistenceService>().FromServicesLocator();
        }
    }
}

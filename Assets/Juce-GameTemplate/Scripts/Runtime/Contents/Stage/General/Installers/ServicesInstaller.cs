using Juce.Core.Di.Builder;
using Juce.CoreUnity.Di.Extensions;
using Juce.CoreUnity.Tick.Services;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Services.Configuration.Service;

namespace Template.Contents.Stage.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDiContainerBuilder container)
        {
            container.Bind<ITickablesService>().FromServicesLocator();
            container.Bind<IUiViewStackService>().FromServicesLocator();
            container.Bind<IConfigurationService>().FromServicesLocator();
        }
    }
}

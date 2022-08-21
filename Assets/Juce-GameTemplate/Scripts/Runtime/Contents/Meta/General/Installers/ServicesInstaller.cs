using Juce.Core.Di.Builder;
using Juce.CoreUnity.Di.Extensions;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Services.Configuration.Service;

namespace Template.Contents.Meta.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDiContainerBuilder container)
        {
            container.Bind<IUiViewStackService>().FromServicesLocator();
            container.Bind<IConfigurationService>().FromServicesLocator();
        }
    }
}

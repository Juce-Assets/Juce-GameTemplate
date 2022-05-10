using Juce.Core.Di.Builder;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.ViewStack.Services;
using JuceUnity.Core.DI.Extensions;

namespace Template.Contents.Stage.General.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IDiContainerBuilder container)
        {
            container.Bind<ITickablesService>().FromServicesLocator();
            container.Bind<IUiViewStackService>().FromServicesLocator();
        }
    }
}

using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.Di.Extensions;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Localization.Services;
using Juce.CoreUnity.Tick.Services;
using Juce.CoreUnity.Ui.Frame;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contexts.Shared.Configuration;
using Template.Contexts.Services.Configuration.Service;

namespace Template.Contexts.Services.General.Installers
{
    public static class ServicesInstaller 
    {
        public static void InstallServices(this IDiContainerBuilder container)
        {
            container.Bind<ILoadingService>()
                .FromInstance(new LoadingService())
                .ToServicesLocator()
                .NonLazy();

            container.Bind<ITickablesService>()
                .FromFunction(c => c.Resolve<TickablesService>())
                .ToServicesLocator()
                .NonLazy();

            container.Bind<IUiViewStackService>()
                .FromFunction(c => new UiViewStackService(
                     c.Resolve<IUiFrame>()
                    ))
                .ToServicesLocator()
                .NonLazy();

            container.Bind<ILocalizationService>()
                .FromInstance(new LocalizationService(
                    ))
                .ToServicesLocator()
                .NonLazy();

            container.Bind<IConfigurationService>()
                .FromFunction(c => new ConfigurationService(
                    c.Resolve<GameConfiguration>()
                    ))
                .ToServicesLocator()
                .NonLazy();
        }
    }
}

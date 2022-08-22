using Juce.Core.Di.Builder;
using Juce.CoreUnity.Di.Extensions;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Localization.Services;
using Juce.CoreUnity.Tick.Services;
using Juce.CoreUnity.Ui.Frame;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contexts.Shared.Configuration;
using Template.Contexts.Services.Configuration.Service;
using Template.Contexts.Services.Persistence.Service;

namespace Template.Contexts.Services.General.Installers
{
    public static class ServicesInstaller 
    {
        public static void InstallServices(this IDiContainerBuilder container)
        {
            container.Bind<ILoadingService>()
                .FromInstance(new LoadingService())
                .ToServicesLocator();

            container.Bind<ITickablesService>()
                .FromFunction(c => c.Resolve<TickablesService>())
                .ToServicesLocator();

            container.Bind<IUiViewStackService>()
                .FromFunction(c => new UiViewStackService(
                     c.Resolve<IUiFrame>()
                    ))
                .ToServicesLocator();

            container.Bind<ILocalizationService>()
                .FromInstance(new LocalizationService(
                    ))
                .ToServicesLocator();

            container.Bind<IConfigurationService>()
                .FromFunction(c => new ConfigurationService(
                    c.Resolve<GameConfiguration>()
                    ))
                .ToServicesLocator();

            container.Bind<IPersistenceService>()
                .FromInstance(new PersistenceService())
                .ToServicesLocator();
        }
    }
}

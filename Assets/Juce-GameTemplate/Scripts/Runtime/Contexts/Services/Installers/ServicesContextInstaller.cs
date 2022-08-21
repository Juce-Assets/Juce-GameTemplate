using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.Di.Extensions;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Localization.Services;
using Juce.CoreUnity.Tick.Services;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Services.Configuration.Service;
using Template.Contents.Services.General.Installers;
using Template.Contents.Services.General.UseCases.LoadServices;

namespace Template.Contexts.Services
{
    public sealed class ServicesContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.Bind<ILoadingService>()
                .FromInstance(new LoadingService())
                .ToServicesLocator()
                .NonLazy();

            container.Bind<ITickablesService>()
                .FromFunction(c => c.Resolve<ServicesContextInstance>().TickablesService)
                .ToServicesLocator()
                .NonLazy();

            container.Bind<IUiViewStackService>()
                .FromFunction(c => new UiViewStackService(
                     c.Resolve<ServicesContextInstance>().UiFrame
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
                    c.Resolve<ServicesContextInstance>().GameConfiguration
                    ))
                .ToServicesLocator()
                .NonLazy();

            container.InstallGeneral();

            container.Bind<IServicesContextInteractor>().FromFunction(c => new ServicesContextInteractor(
                c.Resolve<ILoadServicesUseCase>()
                ));
        }
    }
}

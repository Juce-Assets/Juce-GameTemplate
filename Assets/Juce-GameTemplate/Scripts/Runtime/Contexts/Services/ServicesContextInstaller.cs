using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.ViewStack.Services;
using Juce.Loc.Services;
using JuceUnity.Core.DI.Extensions;
using Template.Contents.Services.General.Installers;
using Template.Contents.Services.General.UseCases.LoadServices;

namespace Template.Contexts.Services
{
    public sealed class ServicesContextInstaller : IContextInstaller<ServicesContextInstance>
    {
        public void Install(IDiContainerBuilder container, ServicesContextInstance context)
        {
            container.Bind<ITickablesService>()
                .FromInstance(context.TickablesService)
                .ToServicesLocator()
                .NonLazy();

            container.Bind<IUiViewStackService>()
                .FromInstance(new UiViewStackService(
                    context.UiFrame
                    ))
                .ToServicesLocator()
                .NonLazy();

            container.Bind<ILocalizationService>()
                .FromInstance(new LocalizationService(
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

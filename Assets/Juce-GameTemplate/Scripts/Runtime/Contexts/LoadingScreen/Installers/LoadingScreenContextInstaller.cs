using Template.Contents.LoadingScreen.General.UseCases.ShowLoadingScreen;
using Juce.Core.Di.Builder;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.LoadingScreen.LoadingScreenUi.Interactor;
using Template.Contents.LoadingScreen.General.UseCases.HideLoadingScreen;
using Template.Contents.LoadingScreen.General.UseCases.RegisterLoadingScreenToLoadingService;
using Juce.CoreUnity.Di.Extensions;
using Juce.Core.Di.Installers;

namespace Template.Contexts.LoadingScreen
{
    public sealed class LoadingScreenContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.Bind<IUiViewStackService>().FromServicesLocator();

            container.Bind<IShowLoadingScreenUseCase>()
                .FromFunction(c => new ShowLoadingScreenUseCase(
                    c.Resolve<IUiViewStackService>(),
                    c.Resolve<ILoadingScreenUiInteractor>()
                    ));

            container.Bind<IHideLoadingScreenUseCase>()
                .FromFunction(c => new HideLoadingScreenUseCase(
                    c.Resolve<ILoadingScreenUiInteractor>()
                    ));

            container.Bind<IRegisterLoadingScreenToLoadingServiceUseCase>()
                .FromFunction(c => new RegisterLoadingScreenToLoadingServiceUseCase(
                    c.Resolve<IShowLoadingScreenUseCase>(),
                    c.Resolve<IHideLoadingScreenUseCase>()
                    ))
                .WhenInit(o => o.Execute)
                .NonLazy();

            container.Bind<ILoadingScreenContextInteractor>().FromInstance(new LoadingScreenContextInteractor());
        }
    }
}

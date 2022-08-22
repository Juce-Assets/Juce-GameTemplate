using Juce.Core.Di.Builder;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.LoadingScreen.LoadingScreenUi.Interactor;
using Template.Contexts.LoadingScreen.General.Interactors;
using Template.Contexts.LoadingScreen.General.UseCases;

namespace Template.Contexts.LoadingScreen.General.Installers
{
    public static class InteractorInstaller
    {
        public static void InstallInteractor(this IDiContainerBuilder container)
        {
            container.Bind<ShowLoadingScreenUseCase>()
                .FromFunction(c => new ShowLoadingScreenUseCase(
                    c.Resolve<IUiViewStackService>(),
                    c.Resolve<ILoadingScreenUiInteractor>()
                    ));

            container.Bind<HideLoadingScreenUseCase>()
                .FromFunction(c => new HideLoadingScreenUseCase(
                    c.Resolve<ILoadingScreenUiInteractor>()
                    ));

            container.Bind<RegisterLoadingScreenToLoadingServiceUseCase>()
                .FromFunction(c => new RegisterLoadingScreenToLoadingServiceUseCase(
                    c.Resolve<ShowLoadingScreenUseCase>(),
                    c.Resolve<HideLoadingScreenUseCase>()
                    ))
                .WhenInit(o => o.Execute)
                .NonLazy();

            container.Bind<ILoadingScreenContextInteractor>()
                .FromInstance(new LoadingScreenContextInteractor(
                    ));
        }
    }
}

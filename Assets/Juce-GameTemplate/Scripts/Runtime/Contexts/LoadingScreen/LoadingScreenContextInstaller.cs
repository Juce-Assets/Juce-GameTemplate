using Template.Contents.LoadingScreen.General.UseCases.ShowLoadingScreen;
using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.ViewStack.Services;
using JuceUnity.Core.DI.Extensions;
using Template.Contents.LoadingScreen.LoadingScreenUi.Interactor;
using Template.Contents.LoadingScreen.General.UseCases.HideLoadingScreen;
using Template.Contents.LoadingScreen.General.UseCases.RegisterLoadingScreenToLoadingService;

namespace Template.Contexts.LoadingScreen
{
    public sealed class LoadingScreenContextInstaller : IContextInstaller<LoadingScreenContextInstance>
    {
        public void Install(IDiContainerBuilder container, LoadingScreenContextInstance context)
        {
            container.Bind<IUiViewStackService>().FromServicesLocator();

            container.Bind(context.LoadingScreenUiInstaller);

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

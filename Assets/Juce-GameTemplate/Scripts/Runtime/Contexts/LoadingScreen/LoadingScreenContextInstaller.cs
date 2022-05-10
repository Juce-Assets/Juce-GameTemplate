using Template.Content.LoadingScreen.General.UseCases.ShowLoadingScreen;
using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.ViewStack.Services;
using JuceUnity.Core.DI.Extensions;
using Template.Content.LoadingScreen.LoadingScreenUi.Interactor;

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

            container.Bind<ILoadingScreenContextInteractor>().FromFunction(c => new LoadingScreenContextInteractor(
                c.Resolve<IShowLoadingScreenUseCase>()
                ));
        }
    }
}

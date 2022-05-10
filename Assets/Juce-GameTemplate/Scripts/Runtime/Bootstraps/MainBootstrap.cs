using Juce.Core.Disposables;
using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Shared.Factories;
using Template.Contexts.LoadingScreen;
using Juce.Core.Loading;
using Template.Content.Meta.SplashScreenUi.Interactor;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack.Services;

namespace Template.Bootstraps
{
    public class MainBootstrap : Bootstrap
    {
        protected override async Task Run(CancellationToken cancellationToken)
        {
            await ContextFactories.Services.Create();
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = await ContextFactories.LoadingScreen.Create();

            ITaskLoadingToken taskLoadingToken = await loadingScreen.Value.Show(cancellationToken);

            await ContextFactories.Cameras.Create();
            await ContextFactories.Meta.Create();

            IUiViewStackService uiViewStackService = ServiceLocator.Get<IUiViewStackService>();

            await taskLoadingToken.Complete();

            await uiViewStackService.New()
                .Show<ISplashScreenUiInteractor>(instantly: false)
                .Hide<ISplashScreenUiInteractor>(instantly: false)
                .Execute(cancellationToken);
        }
    }
}

using Juce.Core.Disposables;
using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Shared.Factories;
using Template.Contexts.LoadingScreen;
using Juce.Core.Loading;
using Template.Contents.Meta.SplashScreenUi.Interactor;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Shared.Logging;

namespace Template.Bootstraps
{
    public sealed class MainBootstrap : Bootstrap
    {
        protected override async Task Run(CancellationToken cancellationToken)
        {
            ITaskLoadingToken taskLoadingToken = await SharedBootstrap.LoadCore(cancellationToken);

            SharedLoggers.BootstrapLogger.Log("Loading meta context");

            await ContextFactories.Meta.Create();

            SharedLoggers.BootstrapLogger.Log("Starting game");

            IUiViewStackService uiViewStackService = ServiceLocator.Get<IUiViewStackService>();

            await taskLoadingToken.Complete();

            await uiViewStackService.New()
                .Show<ISplashScreenUiInteractor>(instantly: false)
                .Hide<ISplashScreenUiInteractor>(instantly: false)
                .Execute(cancellationToken);
        }
    }
}

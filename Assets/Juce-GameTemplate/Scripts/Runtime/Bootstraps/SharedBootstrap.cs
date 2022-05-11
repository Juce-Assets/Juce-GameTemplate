using Juce.Core.Disposables;
using Juce.Core.Loading;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
using Template.Contexts.LoadingScreen;
using Template.Contexts.Shared.Factories;

namespace Template.Bootstraps
{
    public static class SharedBootstrap
    {
        public static async Task<ITaskLoadingToken> LoadCore(CancellationToken cancellationToken)
        {
            SharedLoggers.BootstrapLogger.Log("Loading services context");

            await ContextFactories.Services.Create();

            SharedLoggers.BootstrapLogger.Log("Loading loading screen context");

            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = await ContextFactories.LoadingScreen.Create();

            ITaskLoadingToken taskLoadingToken = await loadingScreen.Value.Show(cancellationToken);

            SharedLoggers.BootstrapLogger.Log("Loading cameras context");

            await ContextFactories.Cameras.Create();

            return taskLoadingToken;
        }
    }
}

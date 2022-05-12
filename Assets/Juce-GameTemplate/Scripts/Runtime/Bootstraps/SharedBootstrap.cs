using Juce.Core.Disposables;
using Juce.Core.Loading;
using Juce.CoreUnity;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
using Template.Contexts.LoadingScreen;
using Template.Contexts.Services;
using Template.Contexts.Shared.Factories;
using UnityEngine;

namespace Template.Bootstraps
{
    public static class SharedBootstrap
    {
        public static async Task<ITaskLoadingToken> LoadCore(CancellationToken cancellationToken)
        {
            SharedLoggers.BootstrapLogger.Log("Starting game {0}", Application.productName);

            if(JuceAppliaction.IsDebug)
            {
                SharedLoggers.BootstrapLogger.Log("Loading debug context");

                await ContextFactories.Debug.Create();
            }

            SharedLoggers.BootstrapLogger.Log("Loading services context");

            ITaskDisposable<IServicesContextInteractor> services = await ContextFactories.Services.Create();

            await services.Value.Load(cancellationToken);

            SharedLoggers.BootstrapLogger.Log("Loading loading screen context");

            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = await ContextFactories.LoadingScreen.Create();

            ITaskLoadingToken taskLoadingToken = await loadingScreen.Value.Show(cancellationToken);

            SharedLoggers.BootstrapLogger.Log("Loading cameras context");

            await ContextFactories.Cameras.Create();

            return taskLoadingToken;
        }
    }
}

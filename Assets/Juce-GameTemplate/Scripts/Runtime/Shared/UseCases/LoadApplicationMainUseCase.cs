using Juce.Core.Disposables;
using Juce.CoreUnity;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
using Template.Contexts.Debug;
using Template.Contexts.Services;
using Template.Contexts.Shared.Factories;
using UnityEngine;

namespace Template.Shared.UseCases
{
    public static class LoadApplicationMainUseCase
    {
        public static async Task Execute(CancellationToken cancellationToken)
        {
            SharedLoggers.BootstrapLogger.Log("Starting game {0}", Application.productName);

            if (JuceAppliaction.IsDebug)
            {
                SharedLoggers.BootstrapLogger.Log("Loading debug context");

                await new SceneDiContext<IDebugContextInteractor, DebugContextInstance>(
                    DebugSceneConstants.SceneName,
                    false,
                    new DebugContextInstaller()
                    ).Install();
            }

            SharedLoggers.BootstrapLogger.Log("Loading services context");

            IAsyncDisposable<IServicesContextInteractor> services = await ContextFactories.Services.Create();

            SharedLoggers.BootstrapLogger.Log("Loading loading screen context");

            await ContextFactories.LoadingScreen.Create();
        }
    }
}
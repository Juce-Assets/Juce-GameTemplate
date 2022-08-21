using Juce.Core.Disposables;
using Juce.CoreUnity;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
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

                await ContextFactories.Debug.Create();
            }

            SharedLoggers.BootstrapLogger.Log("Loading services context");

            ITaskDisposable<IServicesContextInteractor> services = await ContextFactories.Services.Create();

            await services.Value.Preload(cancellationToken);

            SharedLoggers.BootstrapLogger.Log("Loading loading screen context");

            await ContextFactories.LoadingScreen.Create();
        }
    }
}
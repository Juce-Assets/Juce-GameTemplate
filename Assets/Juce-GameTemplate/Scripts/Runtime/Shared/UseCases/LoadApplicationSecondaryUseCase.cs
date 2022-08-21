using Juce.Core.Disposables;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
using Template.Contexts.Services;
using Template.Contexts.Shared.Factories;

namespace Template.Shared.UseCases
{
    public static class LoadApplicationSecondaryUseCase
    {
        public static async Task Execute(CancellationToken cancellationToken)
        {
            IAsyncDisposable<IServicesContextInteractor> services = ServiceLocator.Get<IAsyncDisposable<IServicesContextInteractor>>();

            await services.Value.Load(cancellationToken);

            SharedLoggers.BootstrapLogger.Log("Loading cameras context");

            await ContextFactories.Cameras.Create();
        }
    }
}
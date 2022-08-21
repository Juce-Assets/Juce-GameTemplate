using Juce.Core.Disposables;
using Juce.CoreUnity.Service;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
using Template.Contexts.Stage;

namespace Template.Shared.UseCases
{
    public static class UnloadStageUseCase
    {
        public static async Task Execute(CancellationToken cancellationToken)
        {
            SharedLoggers.BootstrapLogger.Log("Unloading stage context");

            ITaskDisposable<IStageContextInteractor> stageContext = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

            await stageContext.Dispose();
        }
    }
}

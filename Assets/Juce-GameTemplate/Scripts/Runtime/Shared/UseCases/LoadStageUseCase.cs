using Juce.Core.Disposables;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
using Template.Contexts.Shared.Factories;
using Template.Contexts.Stage;

namespace Template.Shared.UseCases
{
    public static class LoadStageUseCase
    {
        public static async Task Execute(CancellationToken cancellationToken)
        {
            SharedLoggers.BootstrapLogger.Log("Loading stage context");

            IAsyncDisposable<IStageContextInteractor> stageContext = await ContextFactories.Stage.Create();
        }
    }
}

using Template.Contexts.Stage;
using Juce.Core.Disposables;
using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Shared.Factories;
using Juce.Core.Loading;
using Template.Contents.Shared.Logging;
using Template.Shared.UseCases;

namespace Template.Bootstraps
{
    public sealed class StageBootstrap : Bootstrap
    {
        protected override async Task Run(CancellationToken cancellationToken)
        {
            ITaskLoadingToken taskLoadingToken = await LoadCoreServicesUseCase.Execute(cancellationToken);

            SharedLoggers.BootstrapLogger.Log("Loading stage context");

            ITaskDisposable<IStageContextInteractor> stageContext = await ContextFactories.Stage.Create();

            stageContext.Value.Load();

            await taskLoadingToken.Complete();

            stageContext.Value.Start();
        }
    }
}

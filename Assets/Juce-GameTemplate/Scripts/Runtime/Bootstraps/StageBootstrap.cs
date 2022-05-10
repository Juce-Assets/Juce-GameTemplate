using Template.Contexts.Stage;
using Juce.Core.Disposables;
using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Shared.Factories;
using Juce.Core.Loading;
using Template.Contexts.LoadingScreen;

namespace Template.Bootstraps
{
    public class StageBootstrap : Bootstrap
    {
        protected override async Task Run(CancellationToken cancellationToken)
        {
            await ContextFactories.Services.Create();
            ITaskDisposable<ILoadingScreenContextInteractor> loadingScreen = await ContextFactories.LoadingScreen.Create();

            ITaskLoadingToken taskLoadingToken = await loadingScreen.Value.Show(cancellationToken);

            await ContextFactories.Cameras.Create();
            await ContextFactories.Meta.Create();

            ITaskDisposable<IStageContextInteractor> stageContext = await ContextFactories.Stage.Create();

            stageContext.Value.Load();

            await taskLoadingToken.Complete();

            stageContext.Value.Start();
        }
    }
}

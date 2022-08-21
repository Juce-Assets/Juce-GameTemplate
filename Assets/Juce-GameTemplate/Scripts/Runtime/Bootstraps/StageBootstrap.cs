using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Template.Shared.UseCases;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Loading.Services;
using Template.Contexts.Stage;
using Juce.Core.Disposables;

namespace Template.Bootstraps
{
    public sealed class StageBootstrap : Bootstrap
    {
        private readonly CachedService<ILoadingService> loadingService;

        protected override async Task Run(CancellationToken cancellationToken)
        {
            await LoadApplicationMainUseCase.Execute(cancellationToken);

            loadingService.Value.Enqueue(
                LoadApplicationSecondaryUseCase.Execute,
                LoadStageUseCase.Execute
                );

            loadingService.Value.Enqueue(() =>
            {
                ITaskDisposable<IStageContextInteractor> stageContext = ServiceLocator.Get<ITaskDisposable<IStageContextInteractor>>();

                stageContext.Value.Start();
            });
        }
    }
}

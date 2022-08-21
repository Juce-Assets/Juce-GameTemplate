using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Meta.SplashScreenUi.Interactor;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Shared.Logging;
using Template.Shared.UseCases;
using Juce.CoreUnity.Loading.Services;
using Juce.Core.Extensions;

namespace Template.Bootstraps
{
    public sealed class MainBootstrap : Bootstrap
    {
        private readonly CachedService<ILoadingService> loadingService;

        protected override async Task Run(CancellationToken cancellationToken)
        {
            await LoadApplicationMainUseCase.Execute(cancellationToken);

            loadingService.Value.Enqueue(
                LoadApplicationSecondaryUseCase.Execute,
                LoadMetaUseCase.Execute
                );

            loadingService.Value.Enqueue(() =>
            {
                SharedLoggers.BootstrapLogger.Log("Starting game");

                IUiViewStackService uiViewStackService = ServiceLocator.Get<IUiViewStackService>();

                uiViewStackService.New()
                    .Show<ISplashScreenUiInteractor>(instantly: false)
                    .Hide<ISplashScreenUiInteractor>(instantly: false)
                    .Execute(cancellationToken).RunAsync();
            });
        }
    }
}

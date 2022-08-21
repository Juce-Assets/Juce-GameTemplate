using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Loading.Services;
using Juce.Core.Contexts;
using Template.Contexts.Debug.General.Context;
using Juce.CoreUnity;
using Template.Contexts.Services.General.Context;
using Template.Shared.UseCases;

namespace Template.Bootstraps
{
    public sealed class MainBootstrap : Bootstrap
    {
        private readonly CachedService<ILoadingService> loadingService;

        protected override async Task Run(CancellationToken cancellationToken)
        {
            IContextsService contextsService = new ContextsService();
            ServiceLocator.Register(contextsService);

            contextsService.Add(new DebugContext());
            contextsService.Add(new ServicesContext());

            if (JuceAppliaction.IsDebug)
            {
                await contextsService.Load<DebugContext>(NopContextData.Instance, cancellationToken);
            }

            await contextsService.Load<ServicesContext>(NopContextData.Instance, cancellationToken);

                //loadingService.Value.New()
                //.Enqueue(
                //    LoadApplicationSecondaryUseCase.Execute,
                //    LoadMetaUseCase.Execute
                //)
                //.Enqueue(() =>
                //{
                //    SharedLoggers.BootstrapLogger.Log("Starting game");

                //    IUiViewStackService uiViewStackService = ServiceLocator.Get<IUiViewStackService>();

                //    uiViewStackService.New()
                //        .Show<ISplashScreenUiInteractor>(instantly: false)
                //        .Hide<ISplashScreenUiInteractor>(instantly: false)
                //        .Execute(cancellationToken).RunAsync();
                //})
                //.Execute();
        }
    }
}

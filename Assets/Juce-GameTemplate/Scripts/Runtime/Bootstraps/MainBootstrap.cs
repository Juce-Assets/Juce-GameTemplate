using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity;
using Juce.Core.Contexts;
using Template.Contexts.Debug.General.Context;
using Template.Contexts.Services.General.Context;
using Template.Contexts.LoadingScreen.General.Context;
using Template.Contexts.Meta.General.Context;
using Template.Contexts.Cameras.General.Context;
using Template.Contexts.Stage.General.Context;
using Template.Contexts.Shared.Logging;

namespace Template.Bootstraps
{
    public sealed class MainBootstrap : Bootstrap
    {
        protected override async Task Run(CancellationToken cancellationToken)
        {
            SharedLoggers.BootstrapLogger.Log("Starting MainBootstrap");

            IContextsService contextsService = new ContextsService();
            ServiceLocator.Register(contextsService);

            contextsService.Add(new DebugContext());
            contextsService.Add(new ServicesContext());
            contextsService.Add(new LoadingScreenContext());
            contextsService.Add(new CamerasContext());
            contextsService.Add(new MetaContext());
            contextsService.Add(new StageContext());

            if (JuceAppliaction.IsDebug)
            {
                await contextsService.Load<DebugContext>(cancellationToken);
            }

            await contextsService.Load<ServicesContext>(cancellationToken);
            await contextsService.Load<LoadingScreenContext>(cancellationToken);

            ServiceLocator.Get<ILoadingService>().New()
                .ShowInstantly()
                .Enqueue(contextsService.Load<CamerasContext>)
                .Enqueue(contextsService.Load<MetaContext>)
                .EnqueueAfterLoad(contextsService.StartCurrent)
                .Execute();
        }
    }
}

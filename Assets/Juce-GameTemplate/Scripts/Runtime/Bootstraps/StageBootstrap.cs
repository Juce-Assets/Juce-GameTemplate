using Juce.CoreUnity.Bootstraps;
using System.Threading;
using System.Threading.Tasks;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Loading.Services;
using Juce.Core.Contexts;
using Template.Contexts.Debug.General.Context;
using Template.Contexts.Services.General.Context;
using Template.Contexts.LoadingScreen.General.Context;
using Template.Contexts.Cameras.General.Context;
using Juce.CoreUnity;
using Template.Contexts.Stage.General.Context;

namespace Template.Bootstraps
{
    public sealed class StageBootstrap : Bootstrap
    {
        protected override async Task Run(CancellationToken cancellationToken)
        {
            IContextsService contextsService = new ContextsService();
            ServiceLocator.Register(contextsService);

            contextsService.Add(new DebugContext());
            contextsService.Add(new ServicesContext());
            contextsService.Add(new LoadingScreenContext());
            contextsService.Add(new CamerasContext());
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
                .Enqueue(contextsService.Load<StageContext>)
                .EnqueueAfterLoad(contextsService.StartCurrent)
                .Execute();
        }
    }
}

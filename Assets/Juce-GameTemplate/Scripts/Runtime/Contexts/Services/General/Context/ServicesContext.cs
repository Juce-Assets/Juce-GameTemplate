using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Services.General.Constants;
using Template.Contexts.Services.General.Installers;
using Template.Contexts.Services.General.Instances;
using Template.Contexts.Services.General.Interactors;
using Template.Contexts.Shared.Logging;

namespace Template.Contexts.Services.General.Context
{
    public sealed class ServicesContext : IContext
    {
        private IAsyncDisposable<IServicesContextInteractor> interactor;

        public async Task Load(IContextData stateData, CancellationToken cancellationToken)
        {
            interactor = await new SceneDiContext<IServicesContextInteractor, ServicesContextInstance>(
                ServicesSceneConstants.SceneName,
                false,
                new ServicesContextInstaller()
                ).Install();

            await interactor.Value.Load(cancellationToken);

            SharedLoggers.ServicesLogger.Log("Context Loaded");
        }

        public void Start()
        {

        }

        public async Task DisposeAsync()
        {
            await interactor.DisposeAsync();

            SharedLoggers.ServicesLogger.Log("Context Unloaded");
        }
    }
}

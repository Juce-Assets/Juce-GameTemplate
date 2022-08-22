using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Debug.General.Constants;
using Template.Contexts.Debug.General.Installers;
using Template.Contexts.Debug.General.Instances;
using Template.Contexts.Debug.General.Interactor;
using Template.Contexts.Shared.Logging;

namespace Template.Contexts.Debug.General.Context
{
    public sealed class DebugContext : IContext
    {
        private IAsyncDisposable<IDebugContextInteractor> interactor;

        public async Task Load(IContextData stateData, CancellationToken cancellationToken)
        {
            interactor = await new SceneDiContext<IDebugContextInteractor, DebugContextInstance>(
                DebugSceneConstants.SceneName,
                false,
                new DebugContextInstaller()
                ).Install();

            SharedLoggers.DebugLogger.Log("Context Loaded");
        }

        public void Start()
        {
           
        }

        public async Task DisposeAsync()
        {
            await interactor.DisposeAsync();

            SharedLoggers.DebugLogger.Log("Context Unloaded");
        }
    }
}

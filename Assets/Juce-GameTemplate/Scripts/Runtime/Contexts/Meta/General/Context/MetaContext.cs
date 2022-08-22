using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Meta.General.Constants;
using Template.Contexts.Meta.General.Installers;
using Template.Contexts.Meta.General.Instances;
using Template.Contexts.Meta.General.Interactors;
using Template.Contexts.Shared.Logging;

namespace Template.Contexts.Meta.General.Context
{
    public sealed class MetaContext : IContext
    {
        private IAsyncDisposable<IMetaContextInteractor> interactor;

        public async Task Load(IContextData stateData, CancellationToken cancellationToken)
        {
            interactor = await new SceneDiContext<IMetaContextInteractor, MetaContextInstance>(
                MetaSceneConstants.SceneName,
                false,
                new MetaContextInstaller()
                ).Install();

            SharedLoggers.MetaLogger.Log("Context Loaded");
        }

        public void Start()
        {
            interactor.Value.Start();

            SharedLoggers.MetaLogger.Log("Context Started");
        }

        public async Task DisposeAsync()
        {
            await interactor.DisposeAsync();

            SharedLoggers.MetaLogger.Log("Context Unloaded");
        }
    }
}

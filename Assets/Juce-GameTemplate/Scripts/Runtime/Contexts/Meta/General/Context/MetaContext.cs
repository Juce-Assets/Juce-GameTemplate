using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Meta.General.Constants;
using Template.Contexts.Meta.General.Installers;
using Template.Contexts.Meta.General.Instances;
using Template.Contexts.Meta.General.Interactors;

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
        }

        public void Start()
        {
            interactor.Value.Start();
        }

        public async Task DisposeAsync()
        {
            await interactor.DisposeAsync();
        }
    }
}

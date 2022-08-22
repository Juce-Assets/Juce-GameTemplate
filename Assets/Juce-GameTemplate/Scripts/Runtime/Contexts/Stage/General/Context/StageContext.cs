using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Stage.General.Constants;
using Template.Contexts.Stage.General.Installers;
using Template.Contexts.Stage.General.Instances;
using Template.Contexts.Stage.General.Interactors;

namespace Template.Contexts.Stage.General.Context
{
    public sealed class StageContext : IContext
    {
        private IAsyncDisposable<IStageContextInteractor> interactor;

        public async Task Load(IContextData stateData, CancellationToken cancellationToken)
        {
            interactor = await new SceneDiContext<IStageContextInteractor, StageContextInstance>(
                StageSceneConstants.SceneName,
                false,
                new StageContextInstaller()
                ).Install();

            await interactor.Value.Load(cancellationToken);
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

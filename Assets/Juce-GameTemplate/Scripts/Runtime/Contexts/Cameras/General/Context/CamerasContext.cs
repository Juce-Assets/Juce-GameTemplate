using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Cameras.General.Constants;
using Template.Contexts.Cameras.General.Installers;
using Template.Contexts.Cameras.General.Instances;
using Template.Contexts.Cameras.General.Interactors;

namespace Template.Contexts.Cameras.General.Context
{
    public sealed class CamerasContext : IContext
    {
        private IAsyncDisposable<ICamerasContextInteractor> interactor;

        public async Task Load(IContextData stateData, CancellationToken cancellationToken)
        {
            interactor = await new SceneDiContext<ICamerasContextInteractor, CamerasContextInstance>(
                CamerasSceneConstants.SceneName,
                false,
                new CamerasContextInstaller()
                ).Install();
        }

        public void Start()
        {

        }

        public async Task DisposeAsync()
        {
            await interactor.DisposeAsync();
        }
    }
}

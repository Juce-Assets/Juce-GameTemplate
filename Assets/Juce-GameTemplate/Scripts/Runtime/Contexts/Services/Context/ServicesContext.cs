using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;

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

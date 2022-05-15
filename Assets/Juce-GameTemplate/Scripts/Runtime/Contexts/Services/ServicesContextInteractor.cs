using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Services.General.UseCases.LoadServices;
using Template.Contents.Services.General.UseCases.PreloadServices;

namespace Template.Contexts.Services
{
    public sealed class ServicesContextInteractor : IServicesContextInteractor
    {
        private readonly IPreloadServicesUseCase preloadServicesUseCase;
        private readonly ILoadServicesUseCase loadServicesUseCase;

        public ServicesContextInteractor(
            IPreloadServicesUseCase preloadServicesUseCase,
            ILoadServicesUseCase loadServicesUseCase
            )
        {
            this.preloadServicesUseCase = preloadServicesUseCase;
            this.loadServicesUseCase = loadServicesUseCase;
        }

        public Task Preload(CancellationToken cancellationToken)
        {
            return preloadServicesUseCase.Execute(cancellationToken);
        }

        public Task Load(CancellationToken cancellationToken)
        {
            return loadServicesUseCase.Execute(cancellationToken);
        }
    }
}

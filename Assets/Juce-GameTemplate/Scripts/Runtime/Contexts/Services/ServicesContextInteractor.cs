using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Services.General.UseCases.LoadServices;

namespace Template.Contexts.Services
{
    public sealed class ServicesContextInteractor : IServicesContextInteractor
    {
        private readonly ILoadServicesUseCase loadServicesUseCase;

        public ServicesContextInteractor(
            ILoadServicesUseCase loadServicesUseCase
            )
        {
            this.loadServicesUseCase = loadServicesUseCase;
        }

        public Task Load(CancellationToken cancellationToken)
        {
            return loadServicesUseCase.Execute(cancellationToken);
        }
    }
}

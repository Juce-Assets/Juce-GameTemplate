using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Services.General.UseCases;

namespace Template.Contexts.Services.General.Interactors
{
    public sealed class ServicesContextInteractor : IServicesContextInteractor
    {
        private readonly LoadUseCase loadUseCase;

        public ServicesContextInteractor(
            LoadUseCase loadUseCase
            )
        {
            this.loadUseCase = loadUseCase;
        }

        public Task Load(CancellationToken cancellationToken)
        {
            return loadUseCase.Execute(cancellationToken);
        }
    }
}

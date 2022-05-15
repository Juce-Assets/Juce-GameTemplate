using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.Services.General.UseCases.LoadServices
{
    public class LoadServicesUseCase : ILoadServicesUseCase
    {
        public LoadServicesUseCase(
            )
        {
           
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

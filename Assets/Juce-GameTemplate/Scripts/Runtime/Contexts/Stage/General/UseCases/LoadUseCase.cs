using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Stage.General.UseCases
{
    public sealed class LoadUseCase
    {
        public LoadUseCase(
   
            )
        {
           
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

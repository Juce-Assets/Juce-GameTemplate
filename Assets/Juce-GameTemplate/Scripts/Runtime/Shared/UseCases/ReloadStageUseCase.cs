using System.Threading;
using System.Threading.Tasks;

namespace Template.Shared.UseCases
{
    public static class ReloadStageUseCase
    {
        public static async Task Execute(CancellationToken cancellationToken)
        {
            await UnloadStageUseCase.Execute(cancellationToken);
            await LoadStageUseCase.Execute(cancellationToken);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.LoadingScreen.General.UseCases.HideLoadingScreen
{
    public interface IHideLoadingScreenUseCase
    {
        Task Execute(bool instantly, CancellationToken cancellationToken);
    }
}

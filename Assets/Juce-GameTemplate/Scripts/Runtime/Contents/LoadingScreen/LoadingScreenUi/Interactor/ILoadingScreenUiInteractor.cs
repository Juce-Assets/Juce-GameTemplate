using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.LoadingScreen.LoadingScreenUi.Interactor
{
    public interface ILoadingScreenUiInteractor
    {
        Task SetVisible(bool visibe, CancellationToken cancellationToken);
    }
}

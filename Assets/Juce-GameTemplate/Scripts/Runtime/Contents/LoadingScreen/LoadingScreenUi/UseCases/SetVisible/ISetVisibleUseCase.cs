using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.LoadingScreen.LoadingScreenUi.UseCases.SetVisible
{
    public interface ISetVisibleUseCase
    {
        Task Execute(bool visible, CancellationToken cancellationToken);
    }
}

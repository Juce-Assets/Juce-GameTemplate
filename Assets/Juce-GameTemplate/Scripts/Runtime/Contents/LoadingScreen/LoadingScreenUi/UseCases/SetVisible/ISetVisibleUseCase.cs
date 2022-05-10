using System.Threading;
using System.Threading.Tasks;

namespace Template.Content.LoadingScreen.LoadingScreenUi.UseCases.SetVisible
{
    public interface ISetVisibleUseCase
    {
        Task Execute(bool visible, CancellationToken cancellationToken);
    }
}

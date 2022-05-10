using System.Threading;
using System.Threading.Tasks;
using Template.Content.LoadingScreen.LoadingScreenUi.UseCases.SetVisible;

namespace Template.Content.LoadingScreen.LoadingScreenUi.Interactor
{
    public sealed class LoadingScreenUiInteractor : ILoadingScreenUiInteractor
    {
        private readonly ISetVisibleUseCase setVisibleUseCase;

        public LoadingScreenUiInteractor(
            ISetVisibleUseCase setVisibleUseCase
            )
        {
            this.setVisibleUseCase = setVisibleUseCase;
        }

        public Task SetVisible(bool visible, CancellationToken cancellationToken)
        {
            return setVisibleUseCase.Execute(visible, cancellationToken);
        }
    }
}

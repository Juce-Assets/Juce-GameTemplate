using System.Threading;
using System.Threading.Tasks;
using Template.Contents.LoadingScreen.LoadingScreenUi.Interactor;

namespace Template.Contents.LoadingScreen.General.UseCases.HideLoadingScreen
{
    public class HideLoadingScreenUseCase : IHideLoadingScreenUseCase
    {
        private readonly ILoadingScreenUiInteractor loadingScreenUiInteractor;

        public HideLoadingScreenUseCase(
            ILoadingScreenUiInteractor loadingScreenUiInteractor
            )
        {
            this.loadingScreenUiInteractor = loadingScreenUiInteractor;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            return loadingScreenUiInteractor.SetVisible(false, cancellationToken);
        }
    }
}

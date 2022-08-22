using System.Threading;
using System.Threading.Tasks;
using Template.Contents.LoadingScreen.LoadingScreenUi.Interactor;

namespace Template.Contexts.LoadingScreen.General.UseCases
{
    public class HideLoadingScreenUseCase 
    {
        private readonly ILoadingScreenUiInteractor loadingScreenUiInteractor;

        public HideLoadingScreenUseCase(
            ILoadingScreenUiInteractor loadingScreenUiInteractor
            )
        {
            this.loadingScreenUiInteractor = loadingScreenUiInteractor;
        }

        public Task Execute(bool instantly, CancellationToken cancellationToken)
        {
            return loadingScreenUiInteractor.SetVisible(false, cancellationToken);
        }
    }
}

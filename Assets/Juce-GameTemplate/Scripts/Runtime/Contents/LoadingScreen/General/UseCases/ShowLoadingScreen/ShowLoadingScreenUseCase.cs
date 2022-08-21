using Juce.Core.Loading.Tokens;
using Juce.CoreUnity.ViewStack.Services;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.LoadingScreen.LoadingScreenUi.Interactor;

namespace Template.Contents.LoadingScreen.General.UseCases.ShowLoadingScreen
{
    public class ShowLoadingScreenUseCase : IShowLoadingScreenUseCase
    {
        private readonly IUiViewStackService uiViewStackService;
        private readonly ILoadingScreenUiInteractor loadingScreenUiInteractor;

        public ShowLoadingScreenUseCase(
            IUiViewStackService uiViewStackService,
            ILoadingScreenUiInteractor loadingScreenUiInteractor
            )
        {
            this.uiViewStackService = uiViewStackService;
            this.loadingScreenUiInteractor = loadingScreenUiInteractor;
        }

        public async Task Execute(bool instantly, CancellationToken cancellationToken)
        {
            await uiViewStackService.New().CurrentSetInteractable(false).Execute(cancellationToken);

            await loadingScreenUiInteractor.SetVisible(visibe: true, cancellationToken);
        }
    }
}

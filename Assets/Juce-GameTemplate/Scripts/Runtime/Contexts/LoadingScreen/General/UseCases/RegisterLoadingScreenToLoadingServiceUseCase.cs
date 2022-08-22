using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Service;

namespace Template.Contexts.LoadingScreen.General.UseCases
{
    public class RegisterLoadingScreenToLoadingServiceUseCase 
    {
        private readonly ShowLoadingScreenUseCase showLoadingScreenUseCase;
        private readonly HideLoadingScreenUseCase hideLoadingScreenUseCase;

        public RegisterLoadingScreenToLoadingServiceUseCase(
            ShowLoadingScreenUseCase showLoadingScreenUseCase,
            HideLoadingScreenUseCase hideLoadingScreenUseCase
            )
        {
            this.showLoadingScreenUseCase = showLoadingScreenUseCase;
            this.hideLoadingScreenUseCase = hideLoadingScreenUseCase;
        }


        public void Execute()
        {
            ILoadingService loadingService = ServiceLocator.Get<ILoadingService>();

            loadingService.AddBeforeLoading(showLoadingScreenUseCase.Execute);
            loadingService.AddAfterLoading(hideLoadingScreenUseCase.Execute);
        }
    }
}

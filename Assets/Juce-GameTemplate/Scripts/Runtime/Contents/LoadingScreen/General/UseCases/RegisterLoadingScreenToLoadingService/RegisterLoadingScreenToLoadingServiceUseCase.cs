using Juce.CoreUnity.Loading.Services;
using Juce.CoreUnity.Service;
using Template.Contents.LoadingScreen.General.UseCases.HideLoadingScreen;
using Template.Contents.LoadingScreen.General.UseCases.ShowLoadingScreen;

namespace Template.Contents.LoadingScreen.General.UseCases.RegisterLoadingScreenToLoadingService
{
    public class RegisterLoadingScreenToLoadingServiceUseCase : IRegisterLoadingScreenToLoadingServiceUseCase
    {
        private readonly IShowLoadingScreenUseCase showLoadingScreenUseCase;
        private readonly IHideLoadingScreenUseCase hideLoadingScreenUseCase;

        public RegisterLoadingScreenToLoadingServiceUseCase(
            IShowLoadingScreenUseCase showLoadingScreenUseCase,
            IHideLoadingScreenUseCase hideLoadingScreenUseCase
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

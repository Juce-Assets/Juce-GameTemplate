using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Meta.SplashScreenUi.Interactor;

namespace Template.Contexts.Meta.General.UseCases
{
    public sealed class StartUseCase
    {
        private readonly IUiViewStackService uiViewStackService;

        public StartUseCase(
            IUiViewStackService uiViewStackService
            )
        {
            this.uiViewStackService = uiViewStackService;
        }

        public void Execute()
        {
            uiViewStackService.New()
                .Show<ISplashScreenUiInteractor>(instantly: false)
                .Hide<ISplashScreenUiInteractor>(instantly: false)
                .Execute();
        }
    }
}

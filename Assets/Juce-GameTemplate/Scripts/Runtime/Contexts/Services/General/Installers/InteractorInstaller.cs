using Juce.Core.Di.Builder;
using Juce.CoreUnity.Localization.Services;
using Template.Contexts.Services.General.Interactors;
using Template.Contexts.Services.General.UseCases;

namespace Template.Contexts.Services.General.Installers
{
    public static class InteractorInstaller 
    {
        public static void InstallInteractor(this IDiContainerBuilder container)
        {
            container.Bind<LoadUseCase>()
                .FromFunction(c => new LoadUseCase(
                    c.Resolve<ILocalizationService>()
                    ));

            container.Bind<IServicesContextInteractor>()
                .FromFunction(c => new ServicesContextInteractor(
                    c.Resolve<LoadUseCase>()
                    ));
        }
    }
}

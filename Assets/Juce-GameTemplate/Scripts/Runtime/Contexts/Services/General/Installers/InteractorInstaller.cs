using Juce.Core.Di.Builder;
using Juce.CoreUnity.Localization.Services;
using Template.Contexts.Services.General.Interactors;
using Template.Contexts.Services.General.UseCases;
using Template.Contexts.Services.Persistence.Service;

namespace Template.Contexts.Services.General.Installers
{
    public static class InteractorInstaller 
    {
        public static void InstallInteractor(this IDiContainerBuilder container)
        {
            container.Bind<LoadUseCase>()
                .FromFunction(c => new LoadUseCase(
                    c.Resolve<ILocalizationService>(),
                    c.Resolve<IPersistenceService>()
                    ));

            container.Bind<IServicesContextInteractor>()
                .FromFunction(c => new ServicesContextInteractor(
                    c.Resolve<LoadUseCase>()
                    ));
        }
    }
}

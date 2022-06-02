using Juce.Core.Di.Builder;
using Juce.CoreUnity.Localization.Services;
using Template.Contents.Services.General.UseCases.LoadServices;
using Template.Contents.Services.General.UseCases.PreloadServices;

namespace Template.Contents.Services.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDiContainerBuilder container)
        {
            container.Bind<IPreloadServicesUseCase>()
                .FromFunction(c => new PreloadServicesUseCase(
                    c.Resolve<ILocalizationService>()
                    ));

            container.Bind<ILoadServicesUseCase>()
                .FromFunction(c => new LoadServicesUseCase(
                    ));
        }
    }
}

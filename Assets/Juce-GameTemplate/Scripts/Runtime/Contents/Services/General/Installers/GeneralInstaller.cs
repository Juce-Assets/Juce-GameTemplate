using Juce.Core.Di.Builder;
using Juce.CoreUnity.Localization.Services;
using Template.Contents.Services.General.UseCases.LoadServices;

namespace Template.Contents.Services.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDiContainerBuilder container)
        {
            container.Bind<ILoadServicesUseCase>()
                .FromFunction(c => new LoadServicesUseCase(
                    c.Resolve<ILocalizationService>()
                    ));
        }
    }
}

using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Template.Contents.Shared.General.Installers;

namespace Template.Contexts.LoadingScreen.General.Installers
{
    public sealed class LoadingScreenContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.InstallServices();
            container.InstallInteractor();
        }
    }
}

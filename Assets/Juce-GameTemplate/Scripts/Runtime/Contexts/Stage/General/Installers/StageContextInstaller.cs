using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Template.Contents.Shared.General.Installers;
using Template.Contexts.Stage.Cheats.Installers;

namespace Template.Contexts.Stage.General.Installers
{
    public sealed class StageContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.InstallServices();
            container.InstallCheats();
            container.InstallInteractor();
        }
    }
}

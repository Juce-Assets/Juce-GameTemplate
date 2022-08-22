using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;

namespace Template.Contexts.Services.General.Installers
{
    public sealed class ServicesContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.InstallServices();
            container.InstallInteractor();
        }
    }
}

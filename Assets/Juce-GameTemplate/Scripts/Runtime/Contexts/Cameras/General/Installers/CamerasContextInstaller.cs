using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Template.Contexts.Cameras.General.Interactors;

namespace Template.Contexts.Cameras.General.Installers
{
    public sealed class CamerasContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.Bind<ICamerasContextInteractor>()
                .FromFunction(c => new CamerasContextInteractor(
                    ));
        }
    }
}

using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;

namespace Template.Contexts.Cameras
{
    public sealed class CamerasContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.Bind<ICamerasContextInteractor>().FromFunction(c => new CamerasContextInteractor(
                ));
        }
    }
}

using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;

namespace Template.Contexts.Cameras
{
    public sealed class CamerasContextInstaller : IContextInstaller<CamerasContextInstance>
    {
        public void Install(IDiContainerBuilder container, CamerasContextInstance context)
        {
            container.Bind<ICamerasContextInteractor>().FromFunction(c => new CamerasContextInteractor(
                ));
        }
    }
}

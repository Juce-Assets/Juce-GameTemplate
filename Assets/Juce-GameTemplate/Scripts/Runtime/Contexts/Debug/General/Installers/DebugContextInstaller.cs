using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;

namespace Template.Contexts.Debug
{
    public sealed class DebugContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.Bind<IDebugContextInteractor>().FromInstance(new DebugContextInteractor());
        }
    }
}

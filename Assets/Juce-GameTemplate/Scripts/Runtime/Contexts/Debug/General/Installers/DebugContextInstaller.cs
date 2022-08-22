using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Template.Contexts.Debug.General.Interactor;

namespace Template.Contexts.Debug.General.Installers
{
    public sealed class DebugContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.Bind<IDebugContextInteractor>().FromInstance(new DebugContextInteractor());
        }
    }
}

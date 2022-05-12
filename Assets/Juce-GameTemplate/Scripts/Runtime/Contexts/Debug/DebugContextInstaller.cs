using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;

namespace Template.Contexts.Debug
{
    public sealed class DebugContextInstaller : IContextInstaller<DebugContextInstance>
    {
        public void Install(IDiContainerBuilder container, DebugContextInstance context)
        {
            container.Bind<IDebugContextInteractor>().FromFunction(c => new DebugContextInteractor(
                ));
        }
    }
}

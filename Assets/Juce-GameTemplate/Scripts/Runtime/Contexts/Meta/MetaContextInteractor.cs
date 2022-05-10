using Juce.Core.Di.Builder;
using Juce.Core.Di.Container;

namespace Template.Contexts.Meta
{
    public class MetaContextInteractor : IMetaContextInteractor
    {
        public MetaContextInteractor(
            )
        {

        }

        public IDiContainer ToContainer()
        {
            IDiContainerBuilder containerBuilder = new DiContainerBuilder();

            return containerBuilder.Build();
        }
    }
}

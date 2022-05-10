using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.ViewStack.Services;
using JuceUnity.Core.DI.Extensions;

namespace Template.Contexts.Services
{
    public sealed class ServicesContextInstaller : IContextInstaller<ServicesContextInstance>
    {
        public void Install(IDiContainerBuilder container, ServicesContextInstance context)
        {
            container.Bind<ITickablesService>()
                .FromInstance(context.TickablesService)
                .ToServicesLocator()
                .NonLazy();

            container.Bind<IUiViewStackService>()
                .FromInstance(new UiViewStackService(
                    context.UiFrame
                    ))
                .ToServicesLocator()
                .NonLazy(); 

            container.Bind<IServicesContextInteractor>().FromFunction(c => new ServicesContextInteractor(
                ));
        }
    }
}

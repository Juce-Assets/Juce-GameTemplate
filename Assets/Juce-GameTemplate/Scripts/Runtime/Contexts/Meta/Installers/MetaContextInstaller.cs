using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.ViewStack.Services;
using Template.Contents.Meta.Cheats.Installers;
using Template.Contents.Meta.General.Installers;
using Template.Contexts.Meta.General.UseCases;

namespace Template.Contexts.Meta
{
    public sealed class MetaContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.InstallServices();

            container.InstallCheats();

            container.Bind<StartUseCase>()
                .FromFunction(c => new StartUseCase(
                    c.Resolve<IUiViewStackService>()
                    ));

            container.Bind<IMetaContextInteractor>().FromFunction(c => new MetaContextInteractor(
                c.Resolve<StartUseCase>()
                ));
        }
    }
}

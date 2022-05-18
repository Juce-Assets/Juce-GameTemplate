using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;
using Template.Contents.Meta.Cheats.Installers;
using Template.Contents.Meta.General.Installers;

namespace Template.Contexts.Meta
{
    public sealed class MetaContextInstaller : IContextInstaller<MetaContextInstance>
    {
        public void Install(IDiContainerBuilder container, MetaContextInstance context)
        {
            container.InstallServices();

            container.InstallCheats();

            container.Bind(context.SplashScreenUiInstaller);

            container.Bind<IMetaContextInteractor>().FromFunction(c => new MetaContextInteractor(
                ));
        }
    }
}

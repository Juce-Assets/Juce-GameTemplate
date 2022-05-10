using Template.Contents.Stage.General.Installers;
using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstaller : IContextInstaller<StageContextInstance>
    {
        public void Install(IDiContainerBuilder container, StageContextInstance context)
        {
            container.Bind<StageContextInstance>().FromInstance(context);

            container.InstallServices();
            container.InstallGeneral();

            container.Bind<IStageContextInteractor>().FromFunction(c => new StageContextInteractor(
                ));
        }
    }
}

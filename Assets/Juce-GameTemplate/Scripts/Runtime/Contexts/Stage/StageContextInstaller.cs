using Template.Contents.Stage.General.Installers;
using Juce.Core.Di.Builder;
using Juce.CoreUnity.Contexts;
using Template.Contents.Stage.General.UseCases.LoadStage;
using Template.Contents.Stage.General.UseCases.StartStage;
using Template.Contents.Stage.Cheats.Installers;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstaller : IContextInstaller<StageContextInstance>
    {
        public void Install(IDiContainerBuilder container, StageContextInstance context)
        {
            container.Bind<StageContextInstance>().FromInstance(context);

            container.InstallServices();
            container.InstallGeneral();

            container.InstallCheats();

            container.Bind<IStageContextInteractor>().FromFunction(c => new StageContextInteractor(
                c.Resolve<ILoadStageUseCase>(),
                c.Resolve<IStartStageUseCase>()
                ));
        }
    }
}

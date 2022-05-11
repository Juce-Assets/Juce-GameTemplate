using Juce.Core.Di.Builder;
using Template.Contents.Stage.General.Data;
using Template.Contents.Stage.General.UseCases.LoadStage;
using Template.Contents.Stage.General.UseCases.StartStage;

namespace Template.Contents.Stage.General.Installers
{
    public static class GeneralInstaller
    {
        public static void InstallGeneral(this IDiContainerBuilder container)
        {
            container.Bind<StageStateData>().FromNew();

            container.Bind<ILoadStageUseCase>()
                .FromFunction(c => new LoadStageUseCase(
                    c.Resolve<StageStateData>()
                    ));

            container.Bind<IStartStageUseCase>()
                .FromFunction(c => new StartStageUseCase(
                    c.Resolve<StageStateData>()
                    ));
        }
    }
}

using Juce.Core.Di.Builder;
using Template.Contexts.Stage.General.UseCases;
using Template.Contexts.Stage.General.Interactors;
using Template.Contexts.Stage.General.Data;

namespace Template.Contexts.Stage.General.Installers
{
    public static class InteractorInstaller 
    {
        public static void InstallInteractor(this IDiContainerBuilder container)
        {
            container.Bind<StageStateData>().FromNew();

            container.Bind<LoadUseCase>()
                .FromFunction(c => new LoadUseCase(
                    ));

            container.Bind<StartUseCase>()
                .FromFunction(c => new StartUseCase(
                    ));

            container.Bind<IStageContextInteractor>()
                .FromFunction(c => new StageContextInteractor(
                    c.Resolve<LoadUseCase>(),
                    c.Resolve<StartUseCase>()
                    ));
        }
    }
}

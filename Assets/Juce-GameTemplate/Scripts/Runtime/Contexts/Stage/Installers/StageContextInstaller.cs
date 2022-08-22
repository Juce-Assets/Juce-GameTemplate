using Template.Contents.Stage.General.Installers;
using Juce.Core.Di.Builder;
using Template.Contents.Stage.Cheats.Installers;
using Juce.Core.Di.Installers;
using Template.Contexts.Stage.General.UseCases;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstaller : IInstaller
    {
        public void Install(IDiContainerBuilder container)
        {
            container.InstallServices();
            container.InstallGeneral();

            container.InstallCheats();

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

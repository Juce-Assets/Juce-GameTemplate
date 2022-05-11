using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Di.Builder;
using Juce.Core.Repositories;
using Template.Contents.Meta.Cheats.UseCases.AddCheats;
using Template.Contents.Meta.Cheats.UseCases.RemoveCheats;

namespace Template.Contents.Meta.Cheats.Installers
{
    public static class CheatsInstaller
    {
        public static void InstallCheats(this IDiContainerBuilder container)
        {
            container.Bind<IRepository<IWidgetInteractor>>()
                .FromInstance(new SimpleRepository<IWidgetInteractor>());

            container.Bind<IAddCheatsUseCase>()
                .FromFunction(c => new AddCheatsUseCase(
                    c.Resolve<IRepository<IWidgetInteractor>>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IRemoveCheatsUseCase>()
                .FromFunction(c => new RemoveCheatsUseCase(
                    c.Resolve<IRepository<IWidgetInteractor>>()
                    ))
                .WhenDispose(o => o.Execute())
                .NonLazy();
        }
    }
}

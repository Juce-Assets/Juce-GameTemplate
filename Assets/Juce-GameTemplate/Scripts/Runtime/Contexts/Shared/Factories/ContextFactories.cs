using Juce.CoreUnity.Contexts;

using Template.Contexts.Cameras;
using Template.Contexts.LoadingScreen;
using Template.Contexts.Meta;
using Template.Contexts.Services;
using Template.Contexts.Stage;

namespace Template.Contexts.Shared.Factories
{
    public static class ContextFactories 
    {
        public static IContextFactory<IServicesContextInteractor, ServicesContextInstance> Services { get; }
        public static IContextFactory<ICamerasContextInteractor, CamerasContextInstance> Cameras { get; }
        public static IContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> LoadingScreen { get; }
        public static IContextFactory<IMetaContextInteractor, MetaContextInstance> Meta { get; }
        public static IContextFactory<IStageContextInteractor, StageContextInstance> Stage { get; }

        static ContextFactories()
        {
             Services = new ContextFactory<IServicesContextInteractor, ServicesContextInstance>(
                "ServicesContext",
                new ServicesContextInstaller()
                );
 
             Cameras = new ContextFactory<ICamerasContextInteractor, CamerasContextInstance>(
                "CamerasContext",
                new CamerasContextInstaller()
                );

             LoadingScreen = new ContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance>(
                "LoadingScreenContext",
                new LoadingScreenContextInstaller()
                );

             Meta = new ContextFactory<IMetaContextInteractor, MetaContextInstance>(
                "MetaContext",
                new MetaContextInstaller()
                );

            Stage = new ContextFactory<IStageContextInteractor, StageContextInstance>(
                "StageContext",
                new StageContextInstaller()
                );
        }
    }
}

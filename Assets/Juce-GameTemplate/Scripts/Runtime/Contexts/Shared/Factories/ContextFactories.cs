using Juce.CoreUnity.Contexts;

using Template.Contexts.Cameras;
using Template.Contexts.Debug;
using Template.Contexts.LoadingScreen;
using Template.Contexts.Meta;
using Template.Contexts.Services;
using Template.Contexts.Stage;

namespace Template.Contexts.Shared.Factories
{
    public static class ContextFactories 
    {
        public static IContextFactory<IDebugContextInteractor, DebugContextInstance> Debug { get; }
        public static IContextFactory<IServicesContextInteractor, ServicesContextInstance> Services { get; }
        public static IContextFactory<ICamerasContextInteractor, CamerasContextInstance> Cameras { get; }
        public static IContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> LoadingScreen { get; }
        public static IContextFactory<IMetaContextInteractor, MetaContextInstance> Meta { get; }
        public static IContextFactory<IStageContextInteractor, StageContextInstance> Stage { get; }

        static ContextFactories()
        {
            Debug = new ContextFactory<IDebugContextInteractor, DebugContextInstance>(
                "DebugContext",
                default
                );

            Services = new ContextFactory<IServicesContextInteractor, ServicesContextInstance>(
                "ServicesContext",
                default
                );
 
             Cameras = new ContextFactory<ICamerasContextInteractor, CamerasContextInstance>(
                "CamerasContext",
                default
                );

             LoadingScreen = new ContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance>(
                "LoadingScreenContext",
                default
                );

             Meta = new ContextFactory<IMetaContextInteractor, MetaContextInstance>(
                "MetaContext",
                default
                );

            Stage = new ContextFactory<IStageContextInteractor, StageContextInstance>(
                "StageContext",
                default
                );
        }
    }
}

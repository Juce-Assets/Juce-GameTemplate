using Juce.CoreUnity.Contexts;
using Template.Contexts.Cameras;
using Template.Contexts.LoadingScreen;
using Template.Contexts.Meta;
using Template.Contexts.Services;
using Template.Contexts.Stage;

namespace Template.Contexts.Shared.Factories
{
    public interface IContextFactories
    {
        IContextFactory<IServicesContextInteractor, ServicesContextInstance> Services { get; }
        IContextFactory<ICamerasContextInteractor, CamerasContextInstance> Cameras { get; }
        IContextFactory<ILoadingScreenContextInteractor, LoadingScreenContextInstance> LoadingScreen { get; }
        IContextFactory<IMetaContextInteractor, MetaContextInstance> Meta { get; }
        IContextFactory<IStageContextInteractor, StageContextInstance> Stage { get; }
    }
}

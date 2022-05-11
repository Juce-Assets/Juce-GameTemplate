
using Template.Contents.Stage.General.UseCases.LoadStage;
using Template.Contents.Stage.General.UseCases.StartStage;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInteractor : IStageContextInteractor
    {
        private readonly ILoadStageUseCase loadStageUseCase;
        private readonly IStartStageUseCase startStageUseCase;

        public StageContextInteractor(
            ILoadStageUseCase loadStageUseCase,
            IStartStageUseCase startStageUseCase
            )
        {
            this.loadStageUseCase = loadStageUseCase;
            this.startStageUseCase = startStageUseCase;
        }

        public void Load()
        {
            loadStageUseCase.Execute();
        }

        public void Start()
        {
            startStageUseCase.Execute();
        }
    }
}

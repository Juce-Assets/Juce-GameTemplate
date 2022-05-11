using Template.Contents.Shared.Logging;
using Template.Contents.Stage.General.Data;

namespace Template.Contents.Stage.General.UseCases.LoadStage
{
    public sealed class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly StageStateData stageStateData;

        public LoadStageUseCase(
            StageStateData stageStateData
            )
        {
            this.stageStateData = stageStateData;
        }

        public void Execute()
        {
            if(stageStateData.Loaded)
            {
                SharedLoggers.StageLogger.Log("Trying to load stage but stage was already loaded");
                return;
            }

            SharedLoggers.StageLogger.Log("Loading stage");

            stageStateData.Loaded = true; 
        }
    }
}

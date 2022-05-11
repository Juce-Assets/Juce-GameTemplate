using Template.Contents.Shared.Logging;
using Template.Contents.Stage.General.Data;

namespace Template.Contents.Stage.General.UseCases.StartStage
{
    public sealed class StartStageUseCase : IStartStageUseCase
    {
        private readonly StageStateData stageStateData;

        public StartStageUseCase(
            StageStateData stageStateData
            )
        {
            this.stageStateData = stageStateData;
        }

        public void Execute()
        {
            if (stageStateData.Started)
            {
                SharedLoggers.StageLogger.Log("Trying to start stage but stage was already started");
                return;
            }

            SharedLoggers.StageLogger.Log("Starting stage");

            stageStateData.Started = true;
        }
    }
}

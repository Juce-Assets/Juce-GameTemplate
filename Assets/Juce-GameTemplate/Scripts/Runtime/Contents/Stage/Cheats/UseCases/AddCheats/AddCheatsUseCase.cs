using Juce.Cheats.Core;
using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Repositories;

namespace Template.Contents.Stage.Cheats.UseCases.AddCheats
{
    public sealed class AddCheatsUseCase : IAddCheatsUseCase
    {
        private readonly IRepository<IWidgetInteractor> cheatsRepository;

        public AddCheatsUseCase(
            IRepository<IWidgetInteractor> cheatsRepository
            )
        {
            this.cheatsRepository = cheatsRepository;
        }

        public void Execute()
        {
            IWidgetInteractor metaCheats = JuceCheats.AddAction("Stage Cheats", () => UnityEngine.Debug.Log("Stage Cheats"));
            cheatsRepository.Add(metaCheats);
        }
    }
}

using Juce.Cheats.Core;
using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Repositories;

namespace Template.Contexts.Stage.Cheats.UseCases
{
    public sealed class AddCheatsUseCase 
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

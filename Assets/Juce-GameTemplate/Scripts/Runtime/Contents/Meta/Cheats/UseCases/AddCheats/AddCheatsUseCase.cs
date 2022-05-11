using Juce.Cheats.Core;
using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Repositories;

namespace Template.Contents.Meta.Cheats.UseCases.AddCheats
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
            IWidgetInteractor metaCheats = JuceCheats.AddAction("Meta Cheats", () => UnityEngine.Debug.Log("Meta Cheats"));
            cheatsRepository.Add(metaCheats);
        }
    }
}

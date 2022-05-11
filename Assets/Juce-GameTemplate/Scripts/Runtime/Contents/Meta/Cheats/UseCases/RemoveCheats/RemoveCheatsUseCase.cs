using Juce.Cheats.Core;
using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Repositories;

namespace Template.Contents.Meta.Cheats.UseCases.RemoveCheats
{
    public sealed class RemoveCheatsUseCase : IRemoveCheatsUseCase
    {
        private readonly IRepository<IWidgetInteractor> optionsDefinitionsRepository;

        public RemoveCheatsUseCase(
            IRepository<IWidgetInteractor> optionsDefinitionsRepository
            )
        {
            this.optionsDefinitionsRepository = optionsDefinitionsRepository;
        }

        public void Execute()
        {
            foreach (IWidgetInteractor definition in optionsDefinitionsRepository.Items)
            {
                JuceCheats.Remove(definition);
            }

            optionsDefinitionsRepository.Clear();
        }
    }
}

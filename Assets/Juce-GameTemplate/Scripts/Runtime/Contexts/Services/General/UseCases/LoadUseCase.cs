using Juce.CoreUnity.Localization.Services;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Services.Persistence.Service;
using Template.Contexts.Shared.Logging;

namespace Template.Contexts.Services.General.UseCases
{
    public sealed class LoadUseCase
    {
        private readonly ILocalizationService localizationService;
        private readonly IPersistenceService persistenceService;

        public LoadUseCase(
            ILocalizationService localizationService,
            IPersistenceService persistenceService
            )
        {
            this.localizationService = localizationService;
            this.persistenceService = persistenceService;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            await localizationService.Load(cancellationToken);

            SharedLoggers.ServicesLogger.Log("Localization loaded with {0} languages and {1} entries",
                localizationService.LanguagesCount,
                localizationService.EntriesCount
                );

            await persistenceService.Load(cancellationToken);
        }
    }
}

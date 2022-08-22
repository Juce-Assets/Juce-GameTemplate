using Juce.CoreUnity.Localization.Services;
using System.Diagnostics;
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
            Stopwatch stopwatch = Stopwatch.StartNew();

            await localizationService.Load(cancellationToken);

            stopwatch.Stop();

            SharedLoggers.ServicesLogger.Log("Localization loaded with {0} languages and {1} entries ({2}ms)",
                localizationService.LanguagesCount,
                localizationService.EntriesCount,
                stopwatch.ElapsedMilliseconds
                );

            stopwatch.Restart();

            await persistenceService.Load(cancellationToken);

            stopwatch.Stop();

            SharedLoggers.ServicesLogger.Log("Persistence loaded ({0}ms)",
                stopwatch.ElapsedMilliseconds
                );
        }
    }
}

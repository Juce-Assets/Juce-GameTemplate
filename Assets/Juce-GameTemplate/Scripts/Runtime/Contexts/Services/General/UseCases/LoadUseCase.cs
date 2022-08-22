using Juce.CoreUnity.Localization.Services;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Shared.Logging;

namespace Template.Contexts.Services.General.UseCases
{
    public sealed class LoadUseCase
    {
        private readonly ILocalizationService localizationService;

        public LoadUseCase(
            ILocalizationService localizationService
            )
        {
            this.localizationService = localizationService;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            await localizationService.Load(cancellationToken);

            SharedLoggers.ServicesLogger.Log("Localization loaded with {0} languages and {1} entries",
                localizationService.LanguagesCount,
                localizationService.EntriesCount
                );
        }
    }
}

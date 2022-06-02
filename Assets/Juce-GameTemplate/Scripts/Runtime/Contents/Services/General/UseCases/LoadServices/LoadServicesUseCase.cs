using Juce.CoreUnity.Localization.Services;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;

namespace Template.Contents.Services.General.UseCases.LoadServices
{
    public class LoadServicesUseCase : ILoadServicesUseCase
    {
        private readonly ILocalizationService localizationService;

        public LoadServicesUseCase(
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

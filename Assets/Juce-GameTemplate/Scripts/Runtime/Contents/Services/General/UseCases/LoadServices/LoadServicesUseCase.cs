using Juce.Loc.Services;
using System.Threading;
using System.Threading.Tasks;

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
        }
    }
}

using Template.Content.LoadingScreen.General.UseCases.ShowLoadingScreen;
using Juce.Core.Loading;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.LoadingScreen
{
    public class LoadingScreenContextInteractor : ILoadingScreenContextInteractor
    {
        private readonly IShowLoadingScreenUseCase showLoadingScreenUseCase;

        public LoadingScreenContextInteractor(
            IShowLoadingScreenUseCase showLoadingScreenUseCase
            )
        {
            this.showLoadingScreenUseCase = showLoadingScreenUseCase;
        }

        public Task<ITaskLoadingToken> Show(CancellationToken cancellationToken)
        {
            return showLoadingScreenUseCase.Execute(cancellationToken);
        }
    }
}

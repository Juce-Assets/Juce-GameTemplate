using Juce.Core.Loading;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Content.LoadingScreen.General.UseCases.ShowLoadingScreen
{
    public interface IShowLoadingScreenUseCase
    {
        Task<ITaskLoadingToken> Execute(CancellationToken cancellationToken);
    }
}

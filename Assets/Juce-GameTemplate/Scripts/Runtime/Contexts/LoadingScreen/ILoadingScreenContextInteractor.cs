using Juce.Core.Loading;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.LoadingScreen
{
    public interface ILoadingScreenContextInteractor
    {
        Task<ITaskLoadingToken> Show(CancellationToken cancellationToken);
    }
}

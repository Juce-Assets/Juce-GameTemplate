using Juce.Core.Loading.Tokens;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.LoadingScreen.General.UseCases.ShowLoadingScreen
{
    public interface IShowLoadingScreenUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}

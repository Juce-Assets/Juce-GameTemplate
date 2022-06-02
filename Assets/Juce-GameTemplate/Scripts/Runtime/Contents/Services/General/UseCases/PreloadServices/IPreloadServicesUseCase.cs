using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.Services.General.UseCases.PreloadServices
{
    public interface IPreloadServicesUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}

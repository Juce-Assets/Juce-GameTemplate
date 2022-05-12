using System.Threading;
using System.Threading.Tasks;

namespace Template.Contents.Services.General.UseCases.LoadServices
{
    public interface ILoadServicesUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}

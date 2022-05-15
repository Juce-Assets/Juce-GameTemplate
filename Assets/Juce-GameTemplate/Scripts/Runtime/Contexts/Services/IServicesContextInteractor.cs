using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Services
{
    public interface IServicesContextInteractor
    {
        Task Preload(CancellationToken cancellationToken);
        Task Load(CancellationToken cancellationToken);
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Services
{
    public interface IServicesContextInteractor
    {
        Task Load(CancellationToken cancellationToken);
    }
}

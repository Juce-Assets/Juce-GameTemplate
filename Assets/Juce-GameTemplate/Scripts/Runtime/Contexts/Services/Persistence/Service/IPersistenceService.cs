using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Services.Persistence.Service
{
    public interface IPersistenceService
    {
        Task Load(CancellationToken cancellationToken);
    }
}
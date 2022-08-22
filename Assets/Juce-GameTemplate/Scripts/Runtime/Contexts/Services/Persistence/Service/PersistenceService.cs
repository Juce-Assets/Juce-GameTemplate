using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Services.Persistence.Service
{
    public sealed class PersistenceService : IPersistenceService
    {
        public Task Load(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
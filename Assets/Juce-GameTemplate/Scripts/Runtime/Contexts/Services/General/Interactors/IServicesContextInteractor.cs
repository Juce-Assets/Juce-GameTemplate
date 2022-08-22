using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Services.General.Interactors
{
    public interface IServicesContextInteractor
    {
        Task Load(CancellationToken cancellationToken);
    }
}

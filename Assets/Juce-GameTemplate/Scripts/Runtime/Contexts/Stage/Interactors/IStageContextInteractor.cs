using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Stage
{
    public interface IStageContextInteractor 
    {
        Task Load(CancellationToken cancellationToken);
        void Start();
    }
}

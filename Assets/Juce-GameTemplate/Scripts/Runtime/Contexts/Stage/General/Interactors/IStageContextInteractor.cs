using System.Threading;
using System.Threading.Tasks;

namespace Template.Contexts.Stage.General.Interactors
{
    public interface IStageContextInteractor 
    {
        Task Load(CancellationToken cancellationToken);
        void Start();
    }
}

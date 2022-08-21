using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Logging;
using Template.Contexts.Shared.Factories;

namespace Template.Shared.UseCases
{
    public static class LoadMetaUseCase
    {
        public static async Task Execute(CancellationToken cancellationToken)
        {
            SharedLoggers.BootstrapLogger.Log("Loading meta context");

            await ContextFactories.Meta.Create();

        }
    }
}


using Template.Contexts.Meta.General.UseCases;

namespace Template.Contexts.Meta
{
    public class MetaContextInteractor : IMetaContextInteractor
    {
        private readonly StartUseCase startUseCase;

        public MetaContextInteractor(
            StartUseCase startUseCase
            )
        {
            this.startUseCase = startUseCase;
        }

        public void Start()
        {
            startUseCase.Execute();
        }
    }
}

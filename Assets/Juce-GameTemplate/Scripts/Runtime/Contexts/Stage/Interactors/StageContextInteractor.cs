﻿using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Stage.General.UseCases.StartStage;
using Template.Contexts.Stage.General.UseCases;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInteractor : IStageContextInteractor
    {
        private readonly LoadUseCase loadUseCase;
        private readonly StartUseCase startUseCase;

        public StageContextInteractor(
            LoadUseCase loadUseCase,
            StartUseCase startUseCase
            )
        {
            this.loadUseCase = loadUseCase;
            this.startUseCase = startUseCase;
        }

        public Task Load(CancellationToken cancellationToken)
        {
            return loadUseCase.Execute(cancellationToken);
        }

        public void Start()
        {
            startUseCase.Execute();
        }
    }
}

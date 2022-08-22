﻿using Juce.Core.Contexts;
using Juce.Core.Disposables;
using Juce.CoreUnity.Di.Contexts;
using System.Threading;
using System.Threading.Tasks;
using Template.Contexts.Services;

namespace Template.Contexts.LoadingScreen.General.Context
{
    public sealed class LoadingScreenContext : IContext
    {
        private IAsyncDisposable<ILoadingScreenContextInteractor> interactor;

        public async Task Load(IContextData stateData, CancellationToken cancellationToken)
        {
            interactor = await new SceneDiContext<ILoadingScreenContextInteractor, LoadingScreenContextInstance>(
                LoadingScreenSceneConstants.SceneName,
                false,
                new LoadingScreenContextInstaller()
                ).Install();
        }

        public void Start()
        {

        }

        public async Task DisposeAsync()
        {
            await interactor.DisposeAsync();
        }
    }
}

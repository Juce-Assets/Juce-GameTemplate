﻿using UnityEngine;
using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.TweenComponent;
using Template.Contents.LoadingScreen.LoadingScreenUi.UseCases.SetVisible;
using Template.Contents.LoadingScreen.LoadingScreenUi.Interactor;

namespace Template.Contents.LoadingScreen.LoadingScreenUi.Installers
{
    public class LoadingScreenUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Tweens")]
        [SerializeField] private TweenPlayer showTween = default;
        [SerializeField] private TweenPlayer hideTween = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<ISetVisibleUseCase>()
                 .FromFunction(c => new SetVisibleUseCase(
                     showTween,
                     hideTween
                     ));

            container.Bind<ILoadingScreenUiInteractor>()
                .FromFunction(c => new LoadingScreenUiInteractor(
                    c.Resolve<ISetVisibleUseCase>()
                    ))
                .NonLazy();
        }
    }
}
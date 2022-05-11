using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.Visibles;
using JuceUnity.Core.Di.Extensions;
using Template.Contents.Meta.SplashScreenUi.Interactor;
using Template.Contents.Meta.SplashScreenUi.ViewStack;
using UnityEngine;

namespace Template.Contents.Meta.SplashScreenUi.Installers
{
    public class SplashScreenUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<SplashScreenUiViewStackEntry>()
                .FromFunction(c => new SplashScreenUiViewStackEntry(
                    typeof(ISplashScreenUiInteractor),
                    gameObject.transform,
                    new TweenPlayerAnimationVisible(
                        showAnimation,
                        hideAnimation
                        ),
                    isPopup: false
                    ))
                .LinkToViewStackService()
                .NonLazy();

            container.Bind<ISplashScreenUiInteractor>()
                .FromFunction(c => new SplashScreenUiInteractor())
                .NonLazy();
        }
    }
}
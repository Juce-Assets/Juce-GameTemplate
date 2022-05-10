using Juce.Core.Di.Installers;
using Template.Content.Meta.SplashScreenUi.Installers;
using UnityEngine;

namespace Template.Contexts.Meta
{
    public sealed class MetaContextInstance : MonoBehaviour
    {
        [SerializeField] private SplashScreenUiInstaller splashScreenUiInstaller = default;

        public IInstaller SplashScreenUiInstaller => splashScreenUiInstaller;
    }
}

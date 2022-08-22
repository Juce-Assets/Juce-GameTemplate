using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Template.Contents.Meta.SplashScreenUi.Installers;
using UnityEngine;

namespace Template.Contexts.Meta
{
    public sealed class MetaContextInstance : MonoBehaviour, IInstaller
    {
        [SerializeField] private SplashScreenUiInstaller splashScreenUiInstaller = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind(splashScreenUiInstaller);
        }
    }
}

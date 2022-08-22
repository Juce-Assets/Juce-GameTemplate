using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Template.Contents.LoadingScreen.LoadingScreenUi.Installers;
using UnityEngine;

namespace Template.Contexts.LoadingScreen
{
    public sealed class LoadingScreenContextInstance : MonoBehaviour, IInstaller
    {
        [SerializeField] private LoadingScreenUiInstaller loadingScreenUiInstaller = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind(loadingScreenUiInstaller);
        }
    }
}

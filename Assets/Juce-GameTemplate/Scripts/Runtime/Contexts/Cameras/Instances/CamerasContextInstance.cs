using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using UnityEngine;

namespace Template.Contexts.Cameras
{
    public sealed class CamerasContextInstance : MonoBehaviour, IInstaller
    {
        [SerializeField] private Camera mainCamera = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<Camera>().FromInstance(mainCamera);
        }
    }
}

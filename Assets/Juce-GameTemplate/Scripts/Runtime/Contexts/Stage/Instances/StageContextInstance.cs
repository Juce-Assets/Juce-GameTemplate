using Cinemachine;
using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using UnityEngine;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstance : MonoBehaviour, IInstaller
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<CinemachineVirtualCamera>().FromInstance(virtualCamera);
        }
    }
}

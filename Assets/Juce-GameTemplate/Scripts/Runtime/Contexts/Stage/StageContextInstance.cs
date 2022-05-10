using Cinemachine;
using UnityEngine;

namespace Template.Contexts.Stage
{
    public sealed class StageContextInstance : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera = default;

        public CinemachineVirtualCamera VirtualCamera => virtualCamera;
    }
}

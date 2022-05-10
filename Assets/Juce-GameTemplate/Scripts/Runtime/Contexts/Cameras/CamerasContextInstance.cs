using UnityEngine;

namespace Template.Contexts.Cameras
{
    public sealed class CamerasContextInstance : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera = default;

        public Camera MainCamera => mainCamera;
    }
}

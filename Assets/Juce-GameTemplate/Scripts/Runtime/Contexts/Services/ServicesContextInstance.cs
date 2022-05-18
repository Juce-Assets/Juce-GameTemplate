using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.Ui.Frame;
using Template.Contents.Services.General.Configuration;
using UnityEngine;

namespace Template.Contexts.Services
{
    public sealed class ServicesContextInstance : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private GameConfiguration gameConfiguraton = default;

        [Header("Services")]
        [SerializeField] private TickablesService tickablesService = default;
        [SerializeField] private UiFrame uiFrame = default;

        public GameConfiguration GameConfiguration => gameConfiguraton;

        public ITickablesService TickablesService => tickablesService;
        public UiFrame UiFrame => uiFrame;
    }
}

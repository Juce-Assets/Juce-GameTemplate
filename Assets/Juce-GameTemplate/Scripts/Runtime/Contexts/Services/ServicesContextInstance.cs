using Juce.CoreUnity.Tickables;
using Juce.CoreUnity.Ui.Frame;
using UnityEngine;

namespace Template.Contexts.Services
{
    public sealed class ServicesContextInstance : MonoBehaviour
    {
        [SerializeField] private TickablesService tickablesService = default;
        [SerializeField] private UiFrame uiFrame = default;

        public ITickablesService TickablesService => tickablesService;
        public UiFrame UiFrame => uiFrame;
    }
}

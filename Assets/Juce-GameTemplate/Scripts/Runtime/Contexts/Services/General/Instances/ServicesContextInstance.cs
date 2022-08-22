using Juce.Core.Di.Builder;
using Juce.Core.Di.Installers;
using Juce.CoreUnity.Tick.Services;
using Juce.CoreUnity.Ui.Frame;
using Template.Contexts.Shared.Configuration;
using UnityEngine;

namespace Template.Contexts.Services.General.Instances
{
    public sealed class ServicesContextInstance : MonoBehaviour, IInstaller
    {
        [Header("Configuration")]
        [SerializeField] private GameConfiguration gameConfiguraton = default;

        [Header("Services")]
        [SerializeField] private TickablesService tickablesService = default;
        [SerializeField] private UiFrame uiFrame = default;

        public void Install(IDiContainerBuilder container)
        {
            container.Bind<TickablesService>().FromInstance(tickablesService);
            container.Bind<IUiFrame>().FromInstance(uiFrame);
            container.Bind<GameConfiguration>().FromInstance(gameConfiguraton);
        }
    }
}

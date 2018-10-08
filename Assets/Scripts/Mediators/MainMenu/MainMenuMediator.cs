using Services;
using Signals.MainMenu;
using Views.MainMenu;

namespace Mediators.MainMenu
{
    public class MainMenuMediator : TargetMediator<MainMenuView>
    {
        /// <summary>
        /// Player settings
        /// </summary>
        [Inject]
        public PlayerSettingsService PlayerSettingsService { get; set; }

        /// <summary>
        /// On load select level signal
        /// </summary>
        [Inject]
        public OnLoadSelectLevelSignal OnLoadSelectLevelSignal { get; set; }

        /// <summary>
        /// On load settings signal
        /// </summary>
        [Inject]
        public OnLoadSettingsSignal OnLoadSettingsSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnInitBestScore += text => { text.text = $"Best Score : {PlayerSettingsService.InitBestScore()}"; };

            View.OnLoadSelectLevel += () => { OnLoadSelectLevelSignal.Dispatch(); };

            View.OnLoadSettings += () => { OnLoadSettingsSignal.Dispatch(); };
        }
    }
}
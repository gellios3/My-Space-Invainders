using Services;
using Signals.MainMenu;
using UnityEngine.SceneManagement;
using Views.MainMenu;

namespace Mediators.MainMenu
{
    public class SelectLevelMediator : TargetMediator<SelectLevelView>
    {
        /// <summary>
        /// On load select level signal
        /// </summary>
        [Inject]
        public OnLoadSelectLevelSignal OnLoadSelectLevelSignal { get; set; }

        /// <summary>
        /// On load main menu signal
        /// </summary>
        [Inject]
        public OnLoadMainMenuSignal OnLoadMainMenuSignal { get; set; }


        /// <summary>
        /// Player settings service
        /// </summary>
        [Inject]
        public PlayerSettingsService PlayerSettingsService { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnLoadMainMenu += () => { OnLoadMainMenuSignal.Dispatch(); };
            View.OnLoadMainGame += level =>
            {
                PlayerSettingsService.UpdateCurrentLevel(level);
                SceneManager.LoadScene("MainGame");
            };

            OnLoadSelectLevelSignal.AddListener(() => { View.ShowContent(); });
        }
    }
}
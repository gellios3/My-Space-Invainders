using Services;
using Signals.MainGame;
using UnityEngine.SceneManagement;
using Views.MainGame.UI;

namespace Mediators.MainGame.UI
{
    public class GameOverMediator : TargetMediator<GameOverView>
    {
        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Player settings
        /// </summary>
        [Inject]
        public PlayerSettingsService PlayerSettingsService { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnLoadSelectLevel += () =>
            {
                PlayerSettingsService.SaveBestScore(PlayerStartsService.Score);
                PlayerSettingsService.HasReturnToSelectLevel = true;
                SceneManager.LoadSceneAsync("MainMenu");
            };

            GameOverSignal.AddListener(() => { View.ShowGameOver(PlayerStartsService.Score); });
        }
    }
}
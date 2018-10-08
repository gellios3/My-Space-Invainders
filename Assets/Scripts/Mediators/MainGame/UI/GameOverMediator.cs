using Services;
using Signals;
using Signals.MainGame;
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
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            GameOverSignal.AddListener(() => { View.ShowGameOver(PlayerStartsService.Score); });
        }
    }
}
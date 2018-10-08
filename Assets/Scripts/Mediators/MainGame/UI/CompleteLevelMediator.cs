using Services;
using Signals;
using Signals.MainGame;
using Views.MainGame.UI;

namespace Mediators.MainGame.UI
{
    public class CompleteLevelMediator : TargetMediator<CompleteLevelView>
    {
        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public CompleteLevelSignal CompleteLevelSignal { get; set; }

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
            CompleteLevelSignal.AddListener(() =>
            {
                if (!PlayerStartsService.HasGameOver)
                {
                    View.ShowDialog(PlayerStartsService.Score);
                }
            });
        }
    }
}
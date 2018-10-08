using Services;
using Signals;
using Signals.MainGame;
using Views.MainGame.UI;

namespace Mediators.MainGame.UI
{
    public class ScoreStatusMediator : TargetMediator<ScoreStatusView>
    {
        /// <summary>
        /// Update score signal
        /// </summary>
        [Inject]
        public UpdateScoreSignal UpdateScoreSignal { get; set; }

        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }
        
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
            CompleteLevelSignal.AddListener(() => { View.gameObject.SetActive(false); });
            GameOverSignal.AddListener(() => { View.gameObject.SetActive(false); });
            UpdateScoreSignal.AddListener(() => View.UpdateScore(PlayerStartsService.Score));
        }
    }
}
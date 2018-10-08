using Services;
using Signals;
using Signals.MainGame;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class ExplosionMediator : TargetMediator<ExplosionView>
    {
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }


        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnDestroyView += () =>
            {
                if (PlayerStartsService.HasGameOver)
                {
                    GameOverSignal.Dispatch();
                }
            };
        }
    }
}
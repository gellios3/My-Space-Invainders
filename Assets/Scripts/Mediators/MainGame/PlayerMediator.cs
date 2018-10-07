using Signals;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class PlayerMediator : TargetMediator<PlayerView>
    {
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
            View.OnDeathPlayer += other =>
            {
                Instantiate(View.PlayerExplosionPrefab, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
                GameOverSignal.Dispatch();
            };
        }
    }
}
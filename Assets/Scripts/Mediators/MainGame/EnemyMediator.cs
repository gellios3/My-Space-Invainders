using Services;
using Signals;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class EnemyMediator : TargetMediator<EnemyView>
    {
        /// <summary>
        /// On hit player signal
        /// </summary>
        [Inject]
        public OnEnemyDeathSignal OnEnemyDeathSignal { get; set; }

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
            View.OnDeathEnemy += other =>
            {
                // create explosion on death enemy
                Instantiate(View.ExplosionPrefab, other.transform.position, other.transform.rotation);
                
                // Destroy enemy and bullet
                Destroy(transform.parent.childCount == 1 ? transform.parent.gameObject : gameObject);
                Destroy(other.gameObject);
                OnEnemyDeathSignal.Dispatch(View);
            };
        }
    }
}
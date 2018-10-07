using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class EnemiesWaveMediator : TargetMediator<EnemiesWaveView>
    {
        /// <summary>
        /// Wave service
        /// </summary>
        [Inject]
        public WaveService WaveService { get; set; }

        /// <summary>
        /// Complete level signal
        /// </summary>
        [Inject]
        public CompleteLevelSignal CompleteLevelSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnStart += () =>
            {
                WaveService.Speed = View.Speed;
                for (var i = 0; i < View.OneTimeFires; i++)
                {
                    InvokeRepeating(nameof(FireRandomEnemy), View.Delay, View.FireRate);
                }
            };
        }

        /// <summary>
        /// File random enemy in enemy wave
        /// </summary>
        private void FireRandomEnemy()
        {
            if (transform.childCount == 0)
            {
                CompleteLevelSignal.Dispatch();
                return;
            }

            var rowIndex = Random.Range(0, transform.childCount);
            var row = transform.GetChild(rowIndex);
            var collIndex = Random.Range(0, row.childCount);
            var enemyView = row.GetChild(collIndex).gameObject.GetComponent<EnemyView>();
            enemyView.Fire();
        }
    }
}
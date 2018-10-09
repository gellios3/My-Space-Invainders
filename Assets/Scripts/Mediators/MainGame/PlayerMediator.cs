using System.Linq;
using Services;
using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class PlayerMediator : TargetMediator<PlayerView>
    {
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

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
            View.OnInitMaterial += (meshRenderer, materials) =>
            {
                var shipColor = PlayerSettingsService.InitShipColor();
                meshRenderer.material = materials.FirstOrDefault(material => material.Color == shipColor).Material;
            };

            View.OnDeathPlayer += other =>
            {
                Instantiate(View.PlayerExplosionPrefab, other.transform.position,
                    other.transform.rotation, View.transform.parent);
                Destroy(gameObject);
                Destroy(other.gameObject);
                PlayerStartsService.HasGameOver = true;
            };
        }
    }
}
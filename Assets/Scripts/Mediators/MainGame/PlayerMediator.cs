using System.Linq;
using Services;
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
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnInitMaterial += (meshRenderer, materials) =>
            {
                meshRenderer.material =
                    materials.FirstOrDefault(material => material.Color == ShipColor.Blue).Material;
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
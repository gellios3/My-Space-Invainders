using Services;
using Signals;
using Views.UI;

namespace Mediators.UI
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
            CompleteLevelSignal.AddListener(() => { View.ShowDialog(PlayerStartsService.Score); });
        }
    }
}
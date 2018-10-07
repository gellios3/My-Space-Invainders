using strange.extensions.command.impl;
using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Commands
{
    public class OnEnemyDeathCommand : Command
    {
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Update score signal
        /// </summary>
        [Inject]
        public UpdateScoreSignal UpdateScoreSignal { get; set; }

        /// <summary>
        /// Enemy view
        /// </summary>
        [Inject]
        public EnemyView EnemyView { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            PlayerStartsService.Score += EnemyView.ScoreValue;
            UpdateScoreSignal.Dispatch();
        }
    }
}
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.MainGame
{
    public class WavesManagerView : EventView
    {
        [SerializeField] private GameObject[] _levels;

        /// <summary>
        /// Player settings
        /// </summary>
        [Inject]
        public PlayerSettingsService PlayerSettingsService { get; set; }

        protected override void Start()
        {
            var level = PlayerSettingsService.CurrentLevel;
            if (_levels[level] != null)
            {
                Instantiate(_levels[level], transform);
            }
        }
    }
}
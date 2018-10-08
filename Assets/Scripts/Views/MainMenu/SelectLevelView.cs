using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.MainMenu
{
    public class SelectLevelView : EventView
    {
        /// <summary>
        /// Content
        /// </summary>
        [SerializeField] private GameObject _content;

        /// <summary>
        /// Current level buttons
        /// </summary>
        [SerializeField] private Button[] _currentLevelBtn;

        /// <summary>
        /// Back to menu btn 
        /// </summary>
        [SerializeField] private Button _backBtn;

        /// <summary>
        /// On load main menu
        /// </summary>
        public event Action OnLoadMainMenu;

        /// <summary>
        /// On load main menu
        /// </summary>
        public event Action<int> OnLoadMainGame;

        protected override void Start()
        {
            for (var i = 0; i < _currentLevelBtn.Length; i++)
            {
                var levelNum = i + 1;
                _currentLevelBtn[i].onClick.AddListener(() => OnLoadMainGame?.Invoke(levelNum));
            }

            _backBtn.onClick.AddListener(() =>
            {
                _content.SetActive(false);
                OnLoadMainMenu?.Invoke();
            });
        }

        /// <summary>
        /// Show content
        /// </summary>
        public void ShowContent()
        {
            _content.SetActive(true);
        }
    }
}
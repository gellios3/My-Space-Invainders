using System;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Views.MainMenu
{
    public class SettingsView : EventView
    {
        /// <summary>
        /// Content
        /// </summary>
        [SerializeField] private GameObject _content;

        /// <summary>
        /// Content
        /// </summary>
        [SerializeField] private Slider _volume;

        /// <summary>
        /// Back to menu btn 
        /// </summary>
        [SerializeField] private Button _backBtn;

        /// <summary>
        /// Ship colors btns
        /// </summary>
        [SerializeField] private ShipColorButton[] _shipColorBtns;

        /// <summary>
        /// On load main menu
        /// </summary>
        public event Action OnLoadMainMenu;

        /// <summary>
        /// On load main menu
        /// </summary>
        public event Action<Slider> OnInitVolume;

        /// <summary>
        /// On change volume
        /// </summary>
        public event Action<float> OnChangeVolume;

        /// <summary>
        /// On load main menu
        /// </summary>
        public event Action<ShipColor> OnChangeColor;


        protected override void Start()
        {
            OnInitVolume?.Invoke(_volume);

            _volume.onValueChanged.AddListener(volume => { OnChangeVolume?.Invoke(volume); });

            foreach (var shipColorBtn in _shipColorBtns)
            {
                shipColorBtn.Button.onClick.AddListener(() => { OnChangeColor?.Invoke(shipColorBtn.Color); });
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
using System;
using strange.extensions.mediation.impl;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.MainMenu
{
    public class MainMenuView : EventView
    {
        /// <summary>
        /// Content
        /// </summary>
        [SerializeField] private GameObject _content;

        /// <summary>
        /// Score txt
        /// </summary>
        [SerializeField] private TextMeshProUGUI _scoreTxt;

        /// <summary>
        /// Select level btn
        /// </summary>
        [SerializeField] private Button _selectLevelBtn;

        /// <summary>
        /// Settings btn
        /// </summary>
        [SerializeField] private Button _settingsBtn;

        /// <summary>
        /// Exit game btn
        /// </summary>
        [SerializeField] private Button _exitGameBtn;

        /// <summary>
        /// Player settings
        /// </summary>
        [Inject]
        public PlayerSettingsService PlayerSettingsService { get; set; }

        /// <summary>
        /// On init best score
        /// </summary>
        public event Action<TextMeshProUGUI> OnInitBestScore;

        /// <summary>
        /// On load select level
        /// </summary>
        public event Action OnLoadSelectLevel;

        /// <summary>
        /// On load settings
        /// </summary>
        public event Action OnLoadSettings;

        protected override void Start()
        {
            OnInitBestScore?.Invoke(_scoreTxt);

            if (PlayerSettingsService.HasReturnToSelectLevel)
            {
                OnLoadSelectLevel?.Invoke();
            }

            _selectLevelBtn.onClick.AddListener(() => { OnLoadSelectLevel?.Invoke(); });
            _settingsBtn.onClick.AddListener(() =>
            {
                _content.SetActive(false);
                OnLoadSettings?.Invoke();
            });
            _exitGameBtn.onClick.AddListener(Application.Quit);
        }

        /// <summary>
        /// Show content
        /// </summary>
        public void ShowContent()
        {
            _content.SetActive(true);
        }

        /// <summary>
        /// Hide content
        /// </summary>
        public void HideContent()
        {
            _content.SetActive(false);
        }
    }
}
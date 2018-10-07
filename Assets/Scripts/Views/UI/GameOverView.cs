using strange.extensions.mediation.impl;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Views.UI
{
    public class GameOverView : EventView
    {
        /// <summary>
        /// Game over content
        /// </summary>
        [SerializeField] private GameObject _gameOverContent;

        /// <summary>
        /// Game over content
        /// </summary>
        [SerializeField] private Button _retryBtn;

        /// <summary>
        /// Score txt
        /// </summary>
        [SerializeField] private TextMeshProUGUI _scoreTxt;

        protected override void Start()
        {
            _retryBtn.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); });
        }

        /// <summary>
        /// Show game over content
        /// </summary>
        public void ShowGameOver(int score)
        {
            _scoreTxt.text = score.ToString();
            _gameOverContent.SetActive(true);
        }
    }
}
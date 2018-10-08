using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.MainGame.UI
{
    public class CompleteLevelView : EventView
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
        /// Game over content
        /// </summary>
        [SerializeField] private Button _menuBtn;
        
        protected override void Start()
        {
            _menuBtn.onClick.AddListener(() => { Debug.LogWarning("LOAD MENU"); });
        }
        
        
        /// <summary>
        /// Show game over content
        /// </summary>
        public void ShowDialog(int score)
        {
            _scoreTxt.text = score.ToString();
            _content.SetActive(true);
        }
    }
}
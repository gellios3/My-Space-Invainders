using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

namespace Views.UI
{
    public class ScoreStatusView : EventView
    {
        [SerializeField] private TextMeshProUGUI _score;

        /// <summary>
        /// Update player score
        /// </summary>
        /// <param name="value"></param>
        public void UpdateScore(int value)
        {
            _score.text = $"Score: {value}";
        }
    }
}
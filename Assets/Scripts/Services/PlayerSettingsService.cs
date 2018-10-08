using System;
using UnityEngine;

namespace Services
{
    public class PlayerSettingsService
    {
        /// <summary>
        /// Ship color
        /// </summary>
        public ShipColor ShipColor { get; private set; } = ShipColor.Gray;

        /// <summary>
        /// Best score
        /// </summary>
        public int BestScore { get; private set; }

        /// <summary>
        /// Best score
        /// </summary>
        public int CurrentLevel { get; private set; }
        
        /// <summary>
        /// Has return to menu
        /// </summary>
        public bool HasReturnToSelectLevel { get; set; }

        /// <summary>
        /// Update current level
        /// </summary>
        /// <param name="level"></param>
        public void UpdateCurrentLevel(int level)
        {
            CurrentLevel = level;
        }

        /// <summary>
        /// Init best score
        /// </summary>
        /// <returns></returns>
        public void SaveBestScore(int score)
        {
            if (score <= BestScore)
                return;
            PlayerPrefs.SetInt("bestScore", score);
            BestScore = score;
        }

        /// <summary>
        /// Init best score
        /// </summary>
        /// <returns></returns>
        public int InitBestScore()
        {
            BestScore = PlayerPrefs.GetInt("bestScore", 0);
            return BestScore;
        }

        /// <summary>
        /// Update ship color
        /// </summary>
        /// <param name="color"></param>
        public void UpdateShipColor(ShipColor color)
        {
            ShipColor = color;
            PlayerPrefs.SetInt("shipColor", (int) ShipColor);
        }
    }

    [Serializable]
    public struct ShipColorMaterial
    {
        public ShipColor Color;
        public Material Material;
    }

    public enum ShipColor
    {
        Red,
        Blue,
        Green,
        Gray
    }
}
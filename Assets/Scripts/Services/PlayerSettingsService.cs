using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class PlayerSettingsService
    {
        /// <summary>
        /// Ship color
        /// </summary>
        public ShipColor ShipColor { get; private set; }

        /// <summary>
        /// Best score
        /// </summary>
        public int BestScore { get; private set; }

        /// <summary>
        /// Best score
        /// </summary>
        public int CurrentLevel { get; private set; }

        /// <summary>
        /// Best score
        /// </summary>
        public float Volume { get; private set; }

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
        /// Update volume
        /// </summary>
        /// <returns></returns>
        public void UpdateVolume(float volume)
        {
            Volume = volume;
            PlayerPrefs.SetFloat("userVolume", Volume);
        }

        /// <summary>
        /// Init volume
        /// </summary>
        /// <returns></returns>
        public float InitVolume()
        {
            Volume = PlayerPrefs.GetFloat("userVolume", 1);
            return Volume;
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
        /// Init ship color
        /// </summary>
        /// <returns></returns>
        public ShipColor InitShipColor()
        {
            ShipColor = (ShipColor) PlayerPrefs.GetInt("shipColor", (int) ShipColor.Gray);
            return ShipColor;
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

    [Serializable]
    public struct ShipColorButton
    {
        public ShipColor Color;
        public Button Button;
    }

    public enum ShipColor
    {
        Red,
        Blue,
        Green,
        Gray
    }
}
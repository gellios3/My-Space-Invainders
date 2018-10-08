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

        public int BestScore { get; private set; }

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
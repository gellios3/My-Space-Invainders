using System;
using UnityEngine;

namespace Services
{
    public class WaveService
    {
        public GoSide Side { get; set; } = GoSide.Right;
        public Vector2 Speed;
    }

    public enum GoSide
    {
        Left,
        Right
    }
}
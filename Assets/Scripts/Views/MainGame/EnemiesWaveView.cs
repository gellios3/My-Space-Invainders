using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class EnemiesWaveView : EventView
    {
        [SerializeField] private float _fireRate;

        public float FireRate => _fireRate;

        [SerializeField] private float _delay;

        public float Delay => _delay;

        [SerializeField] private Vector2 _speed;

        public Vector2 Speed => _speed;

        [SerializeField] private int _oneTimeFires = 2;

        public int OneTimeFires => _oneTimeFires;

        /// <summary>
        /// On start view
        /// </summary>
        public event Action OnStart;

        protected override void Start()
        {
            OnStart?.Invoke();
        }
    }
}
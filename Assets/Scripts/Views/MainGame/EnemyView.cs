using System;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.MainGame
{
    public class EnemyView : EventView
    {
        [SerializeField] private Rigidbody _rigidBody;

        [SerializeField] private GameObject _explosionPrefab;

        public GameObject ExplosionPrefab => _explosionPrefab;

        [SerializeField] private int _scoreValue;
        
        public int ScoreValue => _scoreValue;

        [SerializeField] private GameObject _shot;
        [SerializeField] private Transform _shotSpawn;

        /// <summary>
        /// Wave service
        /// </summary>
        [Inject]
        public WaveService WaveService { get; set; }

        /// <summary>
        /// On view update
        /// </summary>
        public event Action<Collider> OnDeathEnemy;

        public void Fire()
        {
            Instantiate(_shot, _shotSpawn.position, _shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        private void FixedUpdate()
        {
            switch (WaveService.Side)
            {
                case GoSide.Right:
                    _rigidBody.position -= new Vector3(WaveService.Speed.x, 0, 0);
                    break;
                case GoSide.Left:
                    _rigidBody.position += new Vector3(WaveService.Speed.x, 0, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _rigidBody.position = new Vector3
            (
                _rigidBody.position.x, 0, _rigidBody.position.z - WaveService.Speed.y
            );
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
                return;


            if (other.CompareTag("LeftWall"))
            {
                WaveService.Side = GoSide.Left;
                return;
            }

            if (other.CompareTag("RightWall"))
            {
                WaveService.Side = GoSide.Right;
                return;
            }

            if (!other.CompareTag("PlayerBolt"))
                return;
            OnDeathEnemy?.Invoke(other);
        }
    }
}
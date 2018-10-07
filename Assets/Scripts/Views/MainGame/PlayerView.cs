using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class PlayerView : EventView
    {
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private float _speed;
        [SerializeField] private float _tilt;

        [SerializeField] private Transform _leftWall, _rightWall;

        [SerializeField] private GameObject _shot;
        [SerializeField] private Transform _shotSpawn;
        [SerializeField] private float _fireRate;

        [SerializeField] private GameObject _playerExplosionPrefab;

        public GameObject PlayerExplosionPrefab => _playerExplosionPrefab;

        private float _nextFire;

        /// <summary>
        /// On view update
        /// </summary>
        public event Action<Collider> OnDeathPlayer;


        private void Update()
        {
            if (!Input.GetButton("Fire1") || !(Time.time > _nextFire))
                return;
            _nextFire = Time.time + _fireRate;
            Instantiate(_shot, _shotSpawn.position, _shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        private void FixedUpdate()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidBody.velocity = movement * _speed;

            _rigidBody.position = new Vector3
            (
                Mathf.Clamp(_rigidBody.position.x, _leftWall.position.x + 1, _rightWall.position.x - 1), 0, -5
            );

            _rigidBody.rotation = Quaternion.Euler(0, 0, _rigidBody.velocity.x * -_tilt);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy"))
                return;

            OnDeathPlayer?.Invoke(other);
        }
    }
}
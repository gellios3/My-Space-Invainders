using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class BoltView : EventView
    {
        [SerializeField] private float _speed;
        [SerializeField] private bool _fromEnemy;

        protected override void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("PlayerBolt") || !_fromEnemy)
                return;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
using System;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class ExplosionView : EventView
    {
        [SerializeField] private float _lifetime = 2;


        /// <summary>
        /// On start view
        /// </summary>
        public event Action OnDestroyView;


        protected override void Start()
        {
            StartCoroutine(DestroyAfterTime());
        }

        private IEnumerator DestroyAfterTime()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(_lifetime);
                OnDestroyView?.Invoke();
                Destroy(gameObject, _lifetime);
            }
        }
    }
}
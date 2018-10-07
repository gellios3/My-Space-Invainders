using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class ExplosionView : EventView
    {
        [SerializeField] private float _lifetime = 2;

        protected override void Start()
        {
            Destroy(gameObject, _lifetime);
        }
    }
}
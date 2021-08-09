using System;
using UnityEngine;
using Zenject;

namespace ZEscape.VFX
{
    public class BulletImpactEffect : MonoBehaviour, IPoolable<Vector3, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private ParticleSystem ParticleSystem => GetComponent<ParticleSystem>();
        private Transform Transform => transform;

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            Transform.position = position;
            _pool = pool;
        }

        private void Update()
        {
            if (!ParticleSystem.isPlaying)
            {
                _pool.Despawn(this);
            }
        }

        public class Factory : PlaceholderFactory<Vector3, BulletImpactEffect>
        {
        }
    }
}
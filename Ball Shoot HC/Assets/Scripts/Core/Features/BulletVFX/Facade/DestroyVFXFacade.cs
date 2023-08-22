using BallShoot.Core.Features.BulletVFX.Model;
using BallShoot.Core.Features.BulletVFX.Systems.SetUp;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.BulletVFX.Facade
{
    public class DestroyVFXFacade : MonoBehaviour, IPoolable<Vector3, float, IMemoryPool>
    {
        private IMemoryPool _pool;
        private DestroyVFXModel _model;
        private DestroyVFXSetUpSystem _setUpSystem;

        [Inject]
        public void Construct(DestroyVFXModel model, DestroyVFXSetUpSystem setUpSystem)
        {
            _model = model;
            _setUpSystem = setUpSystem;
        }

        public void OnSpawned(Vector3 position, float radius, IMemoryPool pool)
        {
            _model.RuntimeData.SpawnPosition = position;
            _model.RuntimeData.PoisonRadius = radius;
            _pool = pool;

            _setUpSystem.ActivateVFX();
        }
        
        public void OnDespawned()
        {
            _setUpSystem.Reset();
            _pool = null;
        }

        public void Die()
        {
            _pool.Despawn(this);
        }
        
        public class Factory : PlaceholderFactory<Vector3, float, DestroyVFXFacade>
        {
        }
    }
}
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.Systems.SetUp;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Facade
{
    public class BulletFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        private BulletModel _model;
        private IMemoryPool _pool;
        private IBulletSetUpSystem _setUpSystem;

        [Inject]
        public void Construct(BulletModel bulletModel, IBulletSetUpSystem setUpSystem)
        {
            _model = bulletModel;
            _setUpSystem = setUpSystem;
        }
        
        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            _model.RuntimeData.Status = BulletStatus.Recharge;
            _setUpSystem.ResetBullet();
        }
        
        public void OnDespawned()
        {
            _model.RuntimeData.Status = BulletStatus.InActive;
            _pool = null;
        }

        public void Die()
        {
            _pool.Despawn(this); 
        }
        
        public class Factory : PlaceholderFactory<BulletFacade>
        {
        }
    }
}
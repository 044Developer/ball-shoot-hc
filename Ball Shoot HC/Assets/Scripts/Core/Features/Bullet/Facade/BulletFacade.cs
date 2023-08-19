using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.Systems.SetUp;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Facade
{
    public class BulletFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        private BulletModel _bulletModel;
        private IMemoryPool _pool;
        private IBulletSetUpSystem _setUpSystem;

        [Inject]
        public void Construct(BulletModel bulletModel, IBulletSetUpSystem setUpSystem)
        {
            _bulletModel = bulletModel;
            _setUpSystem = setUpSystem;
        }
        
        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            _bulletModel.RuntimeData.ActiveBullets.Add(this);
            _setUpSystem.ResetBullet();
        }
        
        public void OnDespawned()
        {
            _bulletModel.RuntimeData.ActiveBullets.Remove(this);
            _pool.Despawn(this);
            _pool = null;
        }
        
        public class Factory : PlaceholderFactory<BulletFacade>
        {
        }
    }
}
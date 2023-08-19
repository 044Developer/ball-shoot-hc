using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.Systems.Destroy;
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Systems.LifeTime
{
    public class BulletLifeTimeSystem : IBulletLifeTimeSystem
    {
        private readonly BulletFacade _facade;
        private readonly IBulletDestroySystem _destroySystem;

        public BulletLifeTimeSystem(
            BulletFacade facade,
            IBulletDestroySystem destroySystem)
        {
            _facade = facade;
            _destroySystem = destroySystem;
        }
        
        public void Tick()
        {
            if (_facade.Model.RuntimeData.Status != BulletStatus.Fly)
                return;

            CountDownLifeTime();
        }

        private void CountDownLifeTime()
        {
            _facade.Model.RuntimeData.CurrentLifeTime += Time.deltaTime;

            if (_facade.Model.RuntimeData.CurrentLifeTime > _facade.Model.SettingsData.LifeTime)
            {
                _destroySystem.DestroyBullet();
                _facade.Model.RuntimeData.CurrentLifeTime = 0;
            }
        }
    }
}
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
        private readonly BulletModel _model;
        private readonly IBulletDestroySystem _destroySystem;

        public BulletLifeTimeSystem(
            BulletModel model,
            IBulletDestroySystem destroySystem)
        {
            _model = model;
            _destroySystem = destroySystem;
        }
        
        public void Tick()
        {
            if (_model.RuntimeData.Status != BulletStatus.Fly)
                return;

            CountDownLifeTime();
        }

        private void CountDownLifeTime()
        {
            _model.RuntimeData.CurrentLifeTime += Time.deltaTime;

            if (_model.RuntimeData.CurrentLifeTime > _model.SettingsData.LifeTime)
            {
                _destroySystem.DestroyBullet();
                _model.RuntimeData.CurrentLifeTime = 0;
            }
        }
    }
}
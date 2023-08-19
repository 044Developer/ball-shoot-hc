using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Bullet.View;
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Systems.Fly
{
    public class BulletFlySystem : IBulletFlySystem
    {
        private readonly BulletView _view;
        private readonly BulletFacade _facade;

        public BulletFlySystem(BulletView view, BulletFacade facade)
        {
            _view = view;
            _facade = facade;
        }
        
        public void Tick()
        {
            if (_facade.Model.RuntimeData.Status != BulletStatus.Fly)
                return;

            ApplyBulletForce();
        }

        private void ApplyBulletForce()
        {
            _view.Rigidbody.velocity = Vector3.forward * _facade.Model.SettingsData.Speed * Time.deltaTime;
        }
    }
}
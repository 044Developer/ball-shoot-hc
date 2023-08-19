using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.View;
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Systems.Fly
{
    public class BulletFlySystem : IBulletFlySystem
    {
        private readonly BulletView _view;
        private readonly BulletModel _model;

        public BulletFlySystem(BulletView view, BulletModel model)
        {
            _view = view;
            _model = model;
        }
        
        public void Tick()
        {
            if (_model.RuntimeData.Status != BulletStatus.Fly)
                return;

            ApplyBulletForce();
        }

        private void ApplyBulletForce()
        {
            _view.Rigidbody.velocity = Vector3.forward * _model.SettingsData.Speed * Time.deltaTime;
        }
    }
}
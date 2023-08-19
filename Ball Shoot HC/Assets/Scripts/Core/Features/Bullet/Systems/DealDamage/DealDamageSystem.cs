using System;
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.Systems.Destroy;
using BallShoot.Core.Features.Bullet.View;
using BallShoot.Core.Features.Obstacles.Facade;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.DealDamage
{
    public class BulletDealDamageSystem : IInitializable, IDisposable
    {
        private readonly BulletView _view;
        private readonly IBulletDestroySystem _destroySystem;
        private readonly BulletModel _model;

        public BulletDealDamageSystem(
            BulletView view,
            IBulletDestroySystem destroySystem,
            BulletModel model)
        {
            _view = view;
            _destroySystem = destroySystem;
            _model = model;
        }

        public void Initialize()
        {
            _view.CollisionHandler.OnCollisionEnterEvent += OnCollisionEnter;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out ObstacleFacade damageTarget))
                return;

            _model.ExplosionData = new BulletExplosionData(damageTarget.transform.position,
                _view.Transform.localScale.x);
                
            damageTarget.TakeDamage();
            _destroySystem.DestroyBullet();
        }

        public void Dispose()
        {
            _view.CollisionHandler.OnCollisionEnterEvent -= OnCollisionEnter;
        }
    }
}
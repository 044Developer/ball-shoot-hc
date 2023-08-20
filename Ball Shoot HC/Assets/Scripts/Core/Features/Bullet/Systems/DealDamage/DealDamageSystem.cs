using System;
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.Systems.Destroy;
using BallShoot.Core.Features.Bullet.View;
using BallShoot.Core.Features.BulletVFX.Facade;
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
        private readonly DestroyVFXFacade.Factory _vfxFactory;

        public BulletDealDamageSystem(
            BulletView view,
            IBulletDestroySystem destroySystem,
            BulletModel model, DestroyVFXFacade.Factory vfxFactory)
        {
            _view = view;
            _destroySystem = destroySystem;
            _model = model;
            _vfxFactory = vfxFactory;
        }

        public void Initialize()
        {
            _view.CollisionHandler.OnCollisionEnterEvent += OnCollisionEnter;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out ObstacleFacade damageTarget))
                return;

            var hitPosition = damageTarget.transform.position;
            
            CallVFX(hitPosition);
            
            DestroyObstaclesWithinARadius(hitPosition, _model.ExplosionData.Radius);
            
            _destroySystem.DestroyBullet();
        }

        private void CallVFX(Vector3 position)
        {
            _model.ExplosionData = new BulletExplosionData(position,_view.Transform.localScale.x);
            _vfxFactory.Create(_model.ExplosionData.TargetPosition, _model.ExplosionData.Radius);
        }

        private void DestroyObstaclesWithinARadius(Vector3 startPos, float radius)
        {
            RaycastHit[] hits;
            hits = Physics.SphereCastAll(startPos, radius, Vector3.up, 2f);

            foreach (RaycastHit hit in hits)
            {
                if (!hit.transform.TryGetComponent(out ObstacleFacade damageTarget))
                    continue;
                
                if (damageTarget != null)
                {
                    damageTarget.TakeDamage();
                }
            }
        }

        public void Dispose()
        {
            _view.CollisionHandler.OnCollisionEnterEvent -= OnCollisionEnter;
        }
    }
}
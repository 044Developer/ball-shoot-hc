using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.BulletVFX.Facade;
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Systems.Destroy
{
    public class BulletDestroySystem : IBulletDestroySystem
    {
        private readonly BulletFacade _bulletFacade;
        private readonly DestroyVFXFacade.Factory _vfxFactory;

        public BulletDestroySystem(BulletFacade bulletFacade, DestroyVFXFacade.Factory vfxFactory)
        {
            _bulletFacade = bulletFacade;
            _vfxFactory = vfxFactory;
        }
        
        public void DestroyBullet()
        {
            _vfxFactory.Create(Vector3.zero, 2);
            _bulletFacade.Die();
        }
    }
}
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.BulletVFX.Facade;

namespace BallShoot.Core.Features.Bullet.Systems.Destroy
{
    public class BulletDestroySystem : IBulletDestroySystem
    {
        private readonly BulletFacade _bulletFacade;
        private readonly DestroyVFXFacade.Factory _vfxFactory;
        private readonly BulletModel _model;

        public BulletDestroySystem(BulletFacade bulletFacade, DestroyVFXFacade.Factory vfxFactory, BulletModel model)
        {
            _bulletFacade = bulletFacade;
            _vfxFactory = vfxFactory;
            _model = model;
        }
        
        public void DestroyBullet()
        {
            _vfxFactory.Create(_model.ExplosionData.TargetPosition, _model.ExplosionData.Radius);
            _bulletFacade.Die();
        }
    }
}
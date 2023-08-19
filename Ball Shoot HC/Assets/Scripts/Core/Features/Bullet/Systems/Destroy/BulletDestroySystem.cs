using BallShoot.Core.Features.Bullet.Facade;

namespace BallShoot.Core.Features.Bullet.Systems.Destroy
{
    public class BulletDestroySystem : IBulletDestroySystem
    {
        private readonly BulletFacade _bulletFacade;

        public BulletDestroySystem(BulletFacade bulletFacade)
        {
            _bulletFacade = bulletFacade;
        }
        
        public void DestroyBullet()
        {
            _bulletFacade.Die();
        }
    }

    public interface IBulletDestroySystem
    {
        void DestroyBullet();
    }
}
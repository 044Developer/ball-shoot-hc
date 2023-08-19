using BallShoot.Core.Features.Bullet.Systems.Fly;
using BallShoot.Core.Features.Bullet.Systems.LifeTime;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.Update
{
    public class BulletUpdateSystem : ITickable, IFixedTickable
    {
        private readonly IBulletFlySystem _flySystem;
        private readonly IBulletLifeTimeSystem _lifeTimeSystem;

        public BulletUpdateSystem(IBulletFlySystem flySystem, IBulletLifeTimeSystem lifeTimeSystem)
        {
            _flySystem = flySystem;
            _lifeTimeSystem = lifeTimeSystem;
        }
        
        public void Tick()
        {
            _lifeTimeSystem.Tick();
        }

        public void FixedTick()
        {
            _flySystem.Tick();
        }
    }
}
using BallShoot.Core.Features.Bullet.Systems.Fly;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.Update
{
    public class BulletUpdateSystem : ITickable
    {
        private readonly IBulletFlySystem _flySystem;

        public BulletUpdateSystem(IBulletFlySystem flySystem)
        {
            _flySystem = flySystem;
        }
        
        public void Tick()
        {
            _flySystem?.Tick();
        }
    }
}
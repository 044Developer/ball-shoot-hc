using BallShoot.Core.Features.Bullet.Systems.Fly;
using BallShoot.Core.Features.Bullet.Systems.SizeChange;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.Update
{
    public class BulletUpdateSystem : ITickable
    {
        private readonly IBulletChangeSizeSystem _changeSizeSystem;
        private readonly IBulletFlySystem _flySystem;

        public BulletUpdateSystem(IBulletChangeSizeSystem changeSizeSystem, IBulletFlySystem flySystem)
        {
            _changeSizeSystem = changeSizeSystem;
            _flySystem = flySystem;
        }
        
        public void Tick()
        {
            _changeSizeSystem?.Tick();
            _flySystem?.Tick();
        }
    }
}
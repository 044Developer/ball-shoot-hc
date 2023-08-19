using BallShoot.Core.Features.BulletVFX.Systems.LifeTime;
using Zenject;

namespace BallShoot.Core.Features.BulletVFX.Systems.Update
{
    public class DestroyVFXUpdateSystem : ITickable
    {
        private readonly IDestroyVFXLifeTimeSystem _lifeTimeSystem;

        public DestroyVFXUpdateSystem(IDestroyVFXLifeTimeSystem lifeTimeSystem)
        {
            _lifeTimeSystem = lifeTimeSystem;
        }
        
        public void Tick()
        {
            _lifeTimeSystem.Tick();
        }
    }
}
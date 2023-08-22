using BallShoot.Core.Data.Types;
using BallShoot.Core.Features.BulletVFX.Systems.LifeTime;
using BallShoot.Core.Systems.LevelGamePlay;
using Zenject;

namespace BallShoot.Core.Features.BulletVFX.Systems.Update
{
    public class DestroyVFXUpdateSystem : ITickable
    {
        private readonly IDestroyVFXLifeTimeSystem _lifeTimeSystem;
        private readonly ILevelGamePlaySystem _levelGamePlaySystem;

        public DestroyVFXUpdateSystem(IDestroyVFXLifeTimeSystem lifeTimeSystem, ILevelGamePlaySystem levelGamePlaySystem)
        {
            _lifeTimeSystem = lifeTimeSystem;
            _levelGamePlaySystem = levelGamePlaySystem;
        }
        
        public void Tick()
        {
            if (_levelGamePlaySystem.CurrentLevelState != LevelStateType.Play)
                return;
            
            _lifeTimeSystem.Tick();
        }
    }
}
using BallShoot.Core.Data.Types;
using BallShoot.Core.Features.Bullet.Systems.Fly;
using BallShoot.Core.Features.Bullet.Systems.LifeTime;
using BallShoot.Core.Systems.LevelGamePlay;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.Update
{
    public class BulletUpdateSystem : ITickable, IFixedTickable
    {
        private readonly IBulletFlySystem _flySystem;
        private readonly IBulletLifeTimeSystem _lifeTimeSystem;
        private readonly ILevelGamePlaySystem _levelGamePlaySystem;

        public BulletUpdateSystem(IBulletFlySystem flySystem, IBulletLifeTimeSystem lifeTimeSystem, ILevelGamePlaySystem levelGamePlaySystem)
        {
            _flySystem = flySystem;
            _lifeTimeSystem = lifeTimeSystem;
            _levelGamePlaySystem = levelGamePlaySystem;
        }
        
        public void Tick()
        {
            if (_levelGamePlaySystem.CurrentLevelState != LevelStateType.Play)
                return;
            
            _lifeTimeSystem.Tick();
        }

        public void FixedTick()
        {
            if (_levelGamePlaySystem.CurrentLevelState != LevelStateType.Play)
                return;
            
            _flySystem.Tick();
        }
    }
}
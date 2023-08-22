using BallShoot.Core.Data.Types;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.Systems.Jump;
using BallShoot.Core.Features.Player.Systems.LifeTime;
using BallShoot.Core.Systems.LevelGamePlay;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.PlayerUpdate
{
    public class PlayerUpdateSystem : ITickable, IFixedTickable
    {
        private readonly IPlayerLifeTimeSystem _lifeTimeSystem;
        private readonly IPlayerJumpSystem _jumpSystem;
        private readonly PlayerModel _model;
        private readonly ILevelGamePlaySystem _levelGamePlaySystem;

        public PlayerUpdateSystem(IPlayerLifeTimeSystem lifeTimeSystem,
            IPlayerJumpSystem jumpSystem,
            PlayerModel model,
            ILevelGamePlaySystem levelGamePlaySystem)
        {
            _lifeTimeSystem = lifeTimeSystem;
            _jumpSystem = jumpSystem;
            _model = model;
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
            
            _jumpSystem.Tick();
        }
    }
}
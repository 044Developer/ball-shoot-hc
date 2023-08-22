using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.Systems.Jump;
using BallShoot.Core.Features.Player.Systems.LifeTime;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.PlayerUpdate
{
    public class PlayerUpdateSystem : ITickable, IFixedTickable
    {
        private readonly IPlayerLifeTimeSystem _lifeTimeSystem;
        private readonly IPlayerJumpSystem _jumpSystem;
        private readonly PlayerModel _model;

        public PlayerUpdateSystem(IPlayerLifeTimeSystem lifeTimeSystem, IPlayerJumpSystem jumpSystem, PlayerModel model)
        {
            _lifeTimeSystem = lifeTimeSystem;
            _jumpSystem = jumpSystem;
            _model = model;
        }
        
        public void Tick()
        {
            _lifeTimeSystem.Tick();
        }

        public void FixedTick()
        {
            _jumpSystem.Tick();
        }
    }
}
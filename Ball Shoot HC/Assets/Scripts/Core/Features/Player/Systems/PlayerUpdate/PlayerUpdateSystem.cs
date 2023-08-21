using BallShoot.Core.Features.Player.Systems.Jump;
using BallShoot.Core.Features.Player.Systems.LifeTime;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.PlayerUpdate
{
    public class PlayerUpdateSystem : ITickable, IFixedTickable
    {
        private readonly IPlayerLifeTimeSystem _lifeTimeSystem;
        private readonly IPlayerJumpSystem _jumpSystem;

        public PlayerUpdateSystem(IPlayerLifeTimeSystem lifeTimeSystem, IPlayerJumpSystem jumpSystem)
        {
            _lifeTimeSystem = lifeTimeSystem;
            _jumpSystem = jumpSystem;
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
using BallShoot.Core.Features.Player.Systems.PlayerInput;
using BallShoot.Core.Features.Player.Systems.SizeChange;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.PlayerUpdate
{
    public class PlayerUpdateSystem : ITickable
    {
        private readonly IPlayerSizeChangeSystem _sizeChangeSystem;
        private readonly PlayerInputSystem _inputSystem;

        public PlayerUpdateSystem(IPlayerSizeChangeSystem sizeChangeSystem, PlayerInputSystem inputSystem)
        {
            _sizeChangeSystem = sizeChangeSystem;
            _inputSystem = inputSystem;
        }
        
        public void Tick()
        {
            _sizeChangeSystem?.UpdateSize();
            _inputSystem?.ReadInput();
        }
    }
}
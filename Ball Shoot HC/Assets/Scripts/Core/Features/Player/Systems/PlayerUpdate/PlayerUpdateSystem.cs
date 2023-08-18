using BallShoot.Core.Features.Player.Systems.SizeChange;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.PlayerUpdate
{
    public class PlayerUpdateSystem : ITickable
    {
        private readonly IPlayerSizeChangeSystem _sizeChangeSystem;

        public PlayerUpdateSystem(IPlayerSizeChangeSystem sizeChangeSystem)
        {
            _sizeChangeSystem = sizeChangeSystem;
        }
        
        public void Tick()
        {
            _sizeChangeSystem?.UpdateSize();
        }
    }
}
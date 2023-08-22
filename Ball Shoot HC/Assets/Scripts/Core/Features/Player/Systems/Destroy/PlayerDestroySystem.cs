using BallShoot.Core.Data.Types;
using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Systems.LevelGamePlay;

namespace BallShoot.Core.Features.Player.Systems.Destroy
{
    public class PlayerDestroySystem : IPlayerDestroySystem
    {
        private readonly PlayerModel _model;
        private readonly ILevelGamePlaySystem _levelGamePlaySystem;

        public PlayerDestroySystem(PlayerModel model, ILevelGamePlaySystem levelGamePlaySystem)
        {
            _model = model;
            _levelGamePlaySystem = levelGamePlaySystem;
        }
        
        public void Die()
        {
            _model.RuntimeData.Status = PlayerStatus.Died;
        }
    }
}
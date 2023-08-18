using BallShoot.Core.Features.Player.Data;

namespace BallShoot.Core.Features.Player.Models
{
    public class PlayerModel
    {
        public PlayerStatsData StatsData { get; } = new();
        public PlayerAnimationData AnimationData { get; } = new();
        public PlayerInputData InputData { get; } = new();
    }
}
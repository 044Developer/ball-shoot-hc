using BallShoot.Core.Features.Player.Data;

namespace BallShoot.Core.Features.Player.Models
{
    public class PlayerModel
    {
        public PlayerStatsData StatsData { get; set; } = new PlayerStatsData();
        public PlayerAnimationData AnimationData { get; set; } = new PlayerAnimationData();
        public PlayerSettingsData SettingsData { get; set; } = new PlayerSettingsData();
    }
}
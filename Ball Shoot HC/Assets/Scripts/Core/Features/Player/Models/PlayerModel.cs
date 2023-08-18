using BallShoot.Core.Features.Player.Data;

namespace BallShoot.Core.Features.Player.Models
{
    public class PlayerModel
    {
        public PlayerRuntimeData RuntimeData = new PlayerRuntimeData();
        public PlayerSettingsData SettingsData = new PlayerSettingsData();
    }
}
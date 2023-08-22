using BallShoot.Core.Features.Bullet.Data;

namespace BallShoot.Core.Features.Bullet.Model
{
    public class BulletModel
    {
        public BulletSettingsData SettingsData { get; set; } = new BulletSettingsData();
        public BulletRuntimeData RuntimeData { get; set; } = new BulletRuntimeData();
        public BulletExplosionData ExplosionData { get; set; } = new BulletExplosionData();
    }
}
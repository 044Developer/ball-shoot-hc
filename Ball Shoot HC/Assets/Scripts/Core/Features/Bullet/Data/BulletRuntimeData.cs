namespace BallShoot.Core.Features.Bullet.Data
{
    public struct BulletRuntimeData
    {
        public BulletStatus Status;
        public float CurrentScaleForceApplied;

        public BulletRuntimeData(BulletStatus status, float currentScaleForceApplied)
        {
            Status = status;
            CurrentScaleForceApplied = currentScaleForceApplied;
        }
    }
}
using System.Collections.Generic;
using BallShoot.Core.Features.Bullet.Facade;

namespace BallShoot.Core.Features.Bullet.Data
{
    public class BulletRuntimeData
    {
        public BulletStatus Status = BulletStatus.InActive;
        public float CurrentScaleForceApplied = 0f;
        public readonly List<BulletFacade> ActiveBullets = new List<BulletFacade>();
    }
}
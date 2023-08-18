using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Data
{
    public struct BulletExplosionData
    {
        public readonly Vector3 TargetPosition;
        public readonly float Radius;

        public BulletExplosionData(Vector3 targetPosition, float radius)
        {
            TargetPosition = targetPosition;
            Radius = radius;
        }
    }
}
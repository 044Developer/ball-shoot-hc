using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Data
{
    public struct BulletSettingsData
    {
        public readonly Vector3 StartSize;
        public readonly Vector3 StartDamageRadius;
        public readonly float Speed;
        public readonly float LifeTime;
        public readonly float SizeMultiplier;

        public BulletSettingsData(Vector3 startSize, float speed, float sizeMultiplier, Vector3 startDamageRadius, float lifeTime)
        {
            StartSize = startSize;
            Speed = speed;
            SizeMultiplier = sizeMultiplier;
            StartDamageRadius = startDamageRadius;
            LifeTime = lifeTime;
        }
    }
}
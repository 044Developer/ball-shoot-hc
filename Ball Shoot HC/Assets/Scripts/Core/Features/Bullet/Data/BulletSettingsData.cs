using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Data
{
    public struct BulletSettingsData
    {
        public readonly Vector3 StartSize;
        public readonly float Speed;
        public readonly float SizeMultiplier;

        public BulletSettingsData(Vector3 startSize, float speed, float sizeMultiplier)
        {
            StartSize = startSize;
            Speed = speed;
            SizeMultiplier = sizeMultiplier;
        }
    }
}
using UnityEngine;

namespace BallShoot.Core.Features.Road.Data
{
    public struct RoadSettingsData
    {
        public readonly Vector3 RegularSize;
        public readonly Vector3 MinSize;
        public readonly float DecreaseMultiplier;

        public RoadSettingsData(Vector3 regularSize, Vector3 minSize, float decreaseMultiplier)
        {
            RegularSize = regularSize;
            MinSize = minSize;
            DecreaseMultiplier = decreaseMultiplier;
        }
    }
}
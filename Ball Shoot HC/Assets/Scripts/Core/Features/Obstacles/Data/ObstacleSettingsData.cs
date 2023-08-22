using UnityEngine;

namespace BallShoot.Core.Features.Obstacles.Data
{
    public struct ObstacleSettingsData
    {
        public readonly Gradient DestructionGradient;
        public readonly float DestructionDuration;

        public ObstacleSettingsData(Gradient destructionGradient, float destructionDuration)
        {
            DestructionGradient = destructionGradient;
            DestructionDuration = destructionDuration;
        }
    }
}
using UnityEngine;

namespace BallShoot.Core.Features.Player.Data
{
    public struct PlayerSettingsData
    {
        public readonly float AnimationSpeed;
        public readonly AnimationCurve SizeDecreaseCurve;
        public readonly Gradient ColorChangeCurve;

        public PlayerSettingsData(float animationSpeed, AnimationCurve sizeDecreaseCurve, Gradient colorChangeCurve)
        {
            AnimationSpeed = animationSpeed;
            SizeDecreaseCurve = sizeDecreaseCurve;
            ColorChangeCurve = colorChangeCurve;
        }
    }
}
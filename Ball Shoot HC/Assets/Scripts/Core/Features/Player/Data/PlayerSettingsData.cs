using UnityEngine;

namespace BallShoot.Core.Features.Player.Data
{
    public struct PlayerSettingsData
    {
        public readonly float AnimationSpeed;
        public readonly AnimationCurve SizeDecreaseCurve;
        public readonly Gradient ColorChangeCurve;
        public readonly float MinPlayerSize;
        public readonly Vector3 JumpForce;
        public readonly float DelayBetweenJumps;

        public PlayerSettingsData(float animationSpeed, AnimationCurve sizeDecreaseCurve, Gradient colorChangeCurve, float minPlayerSize, Vector3 jumpForce, float delayBetweenJumps)
        {
            AnimationSpeed = animationSpeed;
            SizeDecreaseCurve = sizeDecreaseCurve;
            ColorChangeCurve = colorChangeCurve;
            MinPlayerSize = minPlayerSize;
            JumpForce = jumpForce;
            DelayBetweenJumps = delayBetweenJumps;
        }
    }
}
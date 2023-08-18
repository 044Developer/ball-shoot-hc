using UnityEngine;

namespace BallShoot.Core.Features.Player.Data
{
    public class PlayerAnimationData
    {
        public float AnimationSpeed { get; set; }
        public AnimationCurve SizeDecreaseCurve { get; set; }
        public Gradient ColorChangeCurve { get; set; }
    }
}
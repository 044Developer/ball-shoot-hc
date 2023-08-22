using UnityEngine;

namespace BallShoot.Core.Features.Player.Configs
{
    [CreateAssetMenu(menuName = "Configs/Core/Player", fileName = "player_configuration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [Header("Animation")]
        [SerializeField] private float _animationSpeed;
        [SerializeField] private AnimationCurve _playerSizeAnimationCurve;
        [SerializeField] private Gradient _playerColorGradientCurve;
        [SerializeField] private float _minPlayerSize;

        [Header("Jumping")]
        [SerializeField] private Vector3 _jumpForce;
        [SerializeField] private float _delayBetweenJumps;

        public float AnimationSpeed => _animationSpeed;
        public AnimationCurve PlayerSizeAnimationCurve => _playerSizeAnimationCurve;
        public Gradient PlayerColorGradientCurve => _playerColorGradientCurve;
        public float MinPlayerSize => _minPlayerSize;
        public Vector3 JumpForce => _jumpForce;
        public float DelayBetweenJumps => _delayBetweenJumps;
    }
}
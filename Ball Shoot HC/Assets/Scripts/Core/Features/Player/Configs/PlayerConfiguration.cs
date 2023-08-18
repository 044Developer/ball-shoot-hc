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

        public float AnimationSpeed => _animationSpeed;
        public AnimationCurve PlayerSizeAnimationCurve => _playerSizeAnimationCurve;
        public Gradient PlayerColorGradientCurve => _playerColorGradientCurve;
    }
}
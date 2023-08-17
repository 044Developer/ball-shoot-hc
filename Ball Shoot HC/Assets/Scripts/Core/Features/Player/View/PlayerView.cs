using UnityEngine;

namespace BallShoot.Core.Features.Player.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [Header("Common")]
        [SerializeField] private Transform _playerTransform;

        public Transform PlayerTransform => _playerTransform;
    }
}
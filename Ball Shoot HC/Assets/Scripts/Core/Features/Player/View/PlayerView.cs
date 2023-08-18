using UnityEngine;

namespace BallShoot.Core.Features.Player.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [Header("Common")]
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private MeshRenderer _playerMesh;

        public Transform PlayerTransform => _playerTransform;
        public MeshRenderer PlayerMesh => _playerMesh;
    }
}
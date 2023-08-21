using UnityEngine;

namespace BallShoot.Core.Features.Player.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [Header("Common")]
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private MeshRenderer _playerMesh;
        [SerializeField] private Rigidbody _rigidbody;

        public Transform PlayerTransform => _playerTransform;
        public MeshRenderer PlayerMesh => _playerMesh;
        public Rigidbody Rigidbody => _rigidbody;
    }
}
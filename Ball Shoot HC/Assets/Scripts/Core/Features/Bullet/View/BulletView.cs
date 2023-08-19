using BallShoot.Tools.ObjectCollision;
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.View
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private SphereCollider _collider;
        [SerializeField] private CollisionHandler _collisionHandler;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidbody;
        public SphereCollider Collider => _collider;
        public CollisionHandler CollisionHandler => _collisionHandler;
    }
}
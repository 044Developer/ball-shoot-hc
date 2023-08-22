using BallShoot.Tools.ObjectCollision;
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.View
{
    public interface IBulletView
    {
        public Transform Transform { get; }
        public Rigidbody Rigidbody { get; }
        public SphereCollider Collider { get; }
        public CollisionHandler CollisionHandler { get; }
    }
}
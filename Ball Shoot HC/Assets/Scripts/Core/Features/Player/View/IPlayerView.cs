using BallShoot.Tools.ObjectCollision;
using UnityEngine;

namespace BallShoot.Core.Features.Player.View
{
    public interface IPlayerView
    {
        public Transform PlayerTransform { get; }
        public MeshRenderer PlayerMesh { get; }
        public Rigidbody Rigidbody { get; }
        public CollisionHandler CollisionHandler { get; }
    }
}
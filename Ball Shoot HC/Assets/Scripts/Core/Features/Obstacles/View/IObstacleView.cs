using System.Collections.Generic;
using UnityEngine;

namespace BallShoot.Core.Features.Obstacles.View
{
    public interface IObstacleView
    {
        public Transform Transform { get; }
        public List<GameObject> ObstaclesObject { get; }
        public List<MeshRenderer> ObstaclesMesh { get; }
        public BoxCollider Collider { get; }
    }
}
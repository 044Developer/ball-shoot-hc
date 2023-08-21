using System.Collections.Generic;
using UnityEngine;

namespace BallShoot.Core.Features.Obstacles.View
{
    public class ObstacleView : MonoBehaviour, IObstacleView
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private List<GameObject> _obstaclesObject;
        [SerializeField] private List<MeshRenderer> _obstaclesMesh;
        [SerializeField] private BoxCollider _collider;

        public Transform Transform => _transform;
        public List<GameObject> ObstaclesObject => _obstaclesObject;
        public List<MeshRenderer> ObstaclesMesh => _obstaclesMesh;
        public BoxCollider Collider => _collider;
    }
}
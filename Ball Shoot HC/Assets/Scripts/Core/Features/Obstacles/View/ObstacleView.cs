using System.Collections.Generic;
using UnityEngine;

namespace BallShoot.Core.Features.Obstacles.View
{
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private List<GameObject> _obstaclesObject;
        [SerializeField] private List<MeshRenderer> _obstaclesMesh;

        public Transform Transform => _transform;
        public List<GameObject> ObstaclesObject => _obstaclesObject;
        public List<MeshRenderer> ObstaclesMesh => _obstaclesMesh;
    }
}
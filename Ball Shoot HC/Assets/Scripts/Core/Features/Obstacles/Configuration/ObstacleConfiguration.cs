using UnityEngine;

namespace BallShoot.Core.Features.Obstacles.Configuration
{
    [CreateAssetMenu(menuName = "Configs/Core/Obstacle", fileName = "obstacle_configuration")]
    public class ObstacleConfiguration : ScriptableObject
    {
        [Header("Spawn Settings")]
        [SerializeField] private int _obstacleCount;
        [SerializeField] private float _obstacleOffset;
        [SerializeField] private float _obstacleHeight;
        
        [Header("Animation Settings")]
        [SerializeField] private Gradient _destructionGradient;
        [SerializeField] private float _destructionDuration;

        public int ObstacleCount => _obstacleCount;
        public float ObstacleOffset => _obstacleOffset;
        public float ObstacleHeight => _obstacleHeight;

        public Gradient DestructionGradient => _destructionGradient;
        public float DestructionDuration => _destructionDuration;
    }
}
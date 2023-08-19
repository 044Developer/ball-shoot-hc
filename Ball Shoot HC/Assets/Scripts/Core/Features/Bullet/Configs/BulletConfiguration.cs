using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Configs
{
    [CreateAssetMenu(menuName = "Configs/Core/Bullet", fileName = "bullet_configuration")]
    public class BulletConfiguration : ScriptableObject
    {
        [Header("Common")]
        [SerializeField] private Vector3 _startSize = Vector3.zero;
        [SerializeField] private Vector3 _startDamageRadius = Vector3.zero;
        
        [Header("Move Settings")]
        [SerializeField] private float _speed = 0;
        [SerializeField] private float _lifeTime = 0;

        [Header("Scale Up Settings")]
        [SerializeField] private float _scaleUpMultiplier = 0;

        public Vector3 StartSize => _startSize;
        public Vector3 StartDamageRadius => _startDamageRadius;
        public float Speed => _speed;
        public float LifeTime => _lifeTime;
        public float ScaleUpMultiplier => _scaleUpMultiplier;
    }
}
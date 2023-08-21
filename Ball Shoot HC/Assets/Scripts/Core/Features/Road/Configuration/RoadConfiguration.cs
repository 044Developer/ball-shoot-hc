using UnityEngine;

namespace BallShoot.Core.Features.Road.Configuration
{
    [CreateAssetMenu(menuName = "Configs/Core/Road", fileName = "road_configuration")]
    public class RoadConfiguration : ScriptableObject
    {
        [SerializeField] private Vector3 _regularSize;
        [SerializeField] private Vector3 _minSize;
        [SerializeField] private float _decreaseMultiplier;

        public Vector3 RegularSize => _regularSize;
        public Vector3 MinSize => _minSize;
        public float DecreaseMultiplier => _decreaseMultiplier;
    }
}
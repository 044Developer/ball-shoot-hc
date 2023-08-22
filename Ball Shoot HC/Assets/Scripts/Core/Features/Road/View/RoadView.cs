using UnityEngine;

namespace BallShoot.Core.Features.Road.View
{
    public class RoadView : MonoBehaviour, IRoadView
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;
    }
}
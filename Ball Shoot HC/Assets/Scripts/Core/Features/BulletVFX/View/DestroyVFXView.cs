using UnityEngine;

namespace BallShoot.Core.Features.BulletVFX.View
{
    public class DestroyVFXView : MonoBehaviour, IDestroyVFXView
    {
        [SerializeField] private Transform _particleTransform;
        [SerializeField] private GameObject _particleObject;

        public Transform ParticleTransform => _particleTransform;
        public GameObject ParticleObject => _particleObject;
    }
}
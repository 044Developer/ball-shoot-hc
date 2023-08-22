using UnityEngine;

namespace BallShoot.Core.Features.BulletVFX.View
{
    public interface IDestroyVFXView
    {
        public Transform ParticleTransform { get; }
        public GameObject ParticleObject { get; }
    }
}
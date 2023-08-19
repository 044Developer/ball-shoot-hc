using UnityEngine;

namespace BallShoot.Core.Features.BulletVFX.Configuration
{
    [CreateAssetMenu(menuName = "Configs/Core/Bullet VFX", fileName = "bullet_vfx_configuration")]
    public class DestroyVFXConfiguration : ScriptableObject
    {
        [SerializeField] private float _vfxLifeTime;

        public float VFXLifeTime => _vfxLifeTime;
    }
}
using UnityEngine;

namespace BallShoot.Core.Features.BulletVFX.Data
{
    public class DestroyVFXRuntimeData
    {
        public Vector3 SpawnPosition { get; set; }
        public float PoisonRadius { get; set; }
        public float CurrentLifeTimeDuration { get; set; }
    }
}
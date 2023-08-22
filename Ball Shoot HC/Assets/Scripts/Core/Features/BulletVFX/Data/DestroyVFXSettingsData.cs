namespace BallShoot.Core.Features.BulletVFX.Data
{
    public struct DestroyVFXSettingsData
    {
        public readonly float LifeTimeDuration;

        public DestroyVFXSettingsData(float lifeTimeDuration)
        {
            LifeTimeDuration = lifeTimeDuration;
        }
    }
}
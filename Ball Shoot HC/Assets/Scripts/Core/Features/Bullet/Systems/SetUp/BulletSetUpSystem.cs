using BallShoot.Core.Features.Bullet.Configs;
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Model;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.SetUp
{
    public class BulletSetUpSystem : IInitializable
    {
        private readonly BulletConfiguration _configuration;
        private readonly BulletModel _model;

        public BulletSetUpSystem(BulletConfiguration configuration, BulletModel model)
        {
            _configuration = configuration;
            _model = model;
        }
        
        public void Initialize()
        {
            SetUpSettings();

            SetUpRuntime();
        }

        private void SetUpSettings()
        {
            _model.SettingsData = new BulletSettingsData
            (
                startSize: _configuration.StartSize,
                speed: _configuration.Speed,
                sizeMultiplier: _configuration.ScaleUpMultiplier
            );
        }

        private void SetUpRuntime()
        {
            _model.RuntimeData = new BulletRuntimeData
            (
                status: BulletStatus.InActive,
                currentScaleForceApplied: 0f
            );
        }
    }
}
using BallShoot.Core.Features.Bullet.Configs;
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.View;
using BallShoot.Core.MonoModels;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.SetUp
{
    public class BulletSetUpSystem : IInitializable, IBulletSetUpSystem
    {
        private readonly BulletConfiguration _configuration;
        private readonly BulletModel _model;
        private readonly BulletView _view;
        private readonly CoreSettingsModel _coreSettingsModel;

        public BulletSetUpSystem(
            BulletConfiguration configuration,
            BulletModel model,
            BulletView view,
            CoreSettingsModel coreSettingsModel)
        {
            _configuration = configuration;
            _model = model;
            _view = view;
            _coreSettingsModel = coreSettingsModel;
        }
        
        public void Initialize()
        {
            SetUpSettings();
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

        public void ResetBullet()
        {
            _view.BulletTransform.position = _coreSettingsModel.SpawnPositions.BulletSpawnPosition.position;
        }
    }
}
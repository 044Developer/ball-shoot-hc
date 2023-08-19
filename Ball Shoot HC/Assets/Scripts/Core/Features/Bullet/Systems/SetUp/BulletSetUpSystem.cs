using BallShoot.Core.Features.Bullet.Configs;
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.View;
using BallShoot.Core.MonoModels;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.SetUp
{
    public class BulletSetUpSystem : IInitializable, IBulletSetUpSystem
    {
        private readonly BulletConfiguration _configuration;
        private readonly BulletFacade _facade;
        private readonly BulletView _view;
        private readonly CoreSettingsModel _coreSettingsModel;

        public BulletSetUpSystem(
            BulletConfiguration configuration,
            BulletFacade facade,
            BulletView view,
            CoreSettingsModel coreSettingsModel)
        {
            _configuration = configuration;
            _facade = facade;
            _view = view;
            _coreSettingsModel = coreSettingsModel;
        }
        
        public void Initialize()
        {
            SetUpSettings();
        }

        private void SetUpSettings()
        {
            _facade.Model.SettingsData = new BulletSettingsData
            (
                startSize: _configuration.StartSize,
                speed: _configuration.Speed,
                sizeMultiplier: _configuration.ScaleUpMultiplier,
                startDamageRadius: _configuration.StartDamageRadius,
                lifeTime: _configuration.LifeTime
            );
        }

        public void ResetBullet()
        {
            _view.Transform.position = _coreSettingsModel.SpawnPositions.BulletSpawnPosition.position;
            _view.Rigidbody.velocity = Vector3.zero;
            _view.Transform.localScale = _facade.Model.SettingsData.StartSize;
        }
    }
}
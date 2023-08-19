using BallShoot.Core.Features.BulletVFX.Configuration;
using BallShoot.Core.Features.BulletVFX.Data;
using BallShoot.Core.Features.BulletVFX.Model;
using BallShoot.Core.Features.BulletVFX.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.BulletVFX.Systems.SetUp
{
    public class DestroyVFXSetUpSystem : IInitializable, IDestroyVFXSetUpSystem
    {
        private readonly DestroyVFXModel _model;
        private readonly DestroyVFXConfiguration _configuration;
        private readonly DestroyVFXView _view;

        public DestroyVFXSetUpSystem(DestroyVFXModel model, DestroyVFXConfiguration configuration, DestroyVFXView view)
        {
            _model = model;
            _configuration = configuration;
            _view = view;
        }
        
        public void Initialize()
        {
            _model.Settings = new DestroyVFXSettingsData
            (
                lifeTimeDuration: _configuration.VFXLifeTime
            );
        }

        public void ActivateVFX()
        {
            _view.ParticleTransform.position = _model.RuntimeData.SpawnPosition;
            _view.ParticleTransform.localScale = Vector3.one * _model.RuntimeData.PoisonRadius;
            _view.ParticleObject.SetActive(true);
        }

        public void Reset()
        {
            _model.RuntimeData.PoisonRadius = 0f;
            _model.RuntimeData.SpawnPosition = Vector3.zero;
            _model.RuntimeData.CurrentLifeTimeDuration = 0f;
        }
    }
}
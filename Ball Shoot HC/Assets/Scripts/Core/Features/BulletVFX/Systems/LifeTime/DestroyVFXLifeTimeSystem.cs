using BallShoot.Core.Features.BulletVFX.Facade;
using BallShoot.Core.Features.BulletVFX.Model;
using UnityEngine;

namespace BallShoot.Core.Features.BulletVFX.Systems.LifeTime
{
    public class DestroyVFXLifeTimeSystem : IDestroyVFXLifeTimeSystem
    {
        private readonly DestroyVFXModel _model;
        private readonly DestroyVFXFacade _facade;

        public DestroyVFXLifeTimeSystem(DestroyVFXModel model, DestroyVFXFacade facade)
        {
            _model = model;
            _facade = facade;
        }
        
        public void Tick()
        {
            CountDownDuration();

            CheckLifeTime();
        }

        private void CountDownDuration()
        {
            _model.RuntimeData.CurrentLifeTimeDuration += Time.deltaTime;
        }

        private void CheckLifeTime()
        {
            if (_model.RuntimeData.CurrentLifeTimeDuration < _model.Settings.LifeTimeDuration)
                return;
            
            _facade.Die();
        }
    }
}
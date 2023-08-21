using System;
using BallShoot.Core.Data.Runtime;
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.SizeChange
{
    public class BulletChangeSizeSystem : IInitializable, IDisposable
    {
        private readonly CoreRuntimeData _coreRuntimeData;
        private readonly BulletModel _model;
        private readonly IBulletView _view;

        public BulletChangeSizeSystem(
            CoreRuntimeData coreRuntimeData,
            BulletModel model,
            IBulletView view)
        {
            _coreRuntimeData = coreRuntimeData;
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _coreRuntimeData.OnTapStartedEvent += ActivateSizeChange;
            _coreRuntimeData.OnTapEvent += UpdateSize;
            _coreRuntimeData.OnTapFinishedEvent += DeactivateSizeChange;
        }

        public void Dispose()
        {
            _coreRuntimeData.OnTapStartedEvent -= ActivateSizeChange;
            _coreRuntimeData.OnTapEvent -= UpdateSize;
            _coreRuntimeData.OnTapFinishedEvent -= DeactivateSizeChange;
        }

        private void ActivateSizeChange()
        {
            if (_model.RuntimeData.Status == BulletStatus.InActive)
            {
                _model.RuntimeData.Status = BulletStatus.Recharge;
            }
        }

        private void UpdateSize()
        {
            if (_model.RuntimeData.Status != BulletStatus.Recharge)
                return;
            
            _view.Transform.localScale += Vector3.one * _model.SettingsData.SizeMultiplier * Time.deltaTime;
        }

        private void DeactivateSizeChange()
        {
            if (_model.RuntimeData.Status != BulletStatus.Recharge)
                return;
            
            _model.RuntimeData.Status = BulletStatus.Fly;
        }
    }
}
using System;
using BallShoot.Core.Data.Runtime;
using BallShoot.Core.Features.Bullet.Data;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.SizeChange
{
    public class BulletChangeSizeSystem : IInitializable, IDisposable
    {
        private readonly CoreRuntimeData _coreRuntimeData;
        private readonly BulletFacade _facade;
        private readonly BulletView _view;

        public BulletChangeSizeSystem(
            CoreRuntimeData coreRuntimeData,
            BulletFacade facade,
            BulletView view)
        {
            _coreRuntimeData = coreRuntimeData;
            _facade = facade;
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
            _facade.Model.RuntimeData.Status = BulletStatus.Recharge;
        }

        private void UpdateSize()
        {
            if (_facade.Model.RuntimeData.Status != BulletStatus.Recharge)
                return;
            
            _view.Transform.localScale += Vector3.one * _facade.Model.SettingsData.SizeMultiplier * Time.deltaTime;
        }

        private void DeactivateSizeChange()
        {
            _facade.Model.RuntimeData.Status = BulletStatus.Fly;
        }
    }
}
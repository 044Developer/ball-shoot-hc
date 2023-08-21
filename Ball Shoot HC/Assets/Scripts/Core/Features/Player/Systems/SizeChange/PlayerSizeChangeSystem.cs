using System;
using BallShoot.Core.Data.Runtime;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.SizeChange
{
    public class PlayerSizeChangeSystem : IInitializable, IDisposable
    {
        private readonly IPlayerView _view;
        private readonly PlayerModel _playerModel;
        private readonly CoreRuntimeData _coreRuntimeData;
        private readonly BulletFacade.Factory _bulletPool;

        public PlayerSizeChangeSystem(IPlayerView view, PlayerModel playerModel, CoreRuntimeData coreRuntimeData, BulletFacade.Factory bulletPool)
        {
            _view = view;
            _playerModel = playerModel;
            _coreRuntimeData = coreRuntimeData;
            _bulletPool = bulletPool;
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
            if (_playerModel.RuntimeData.Status == PlayerStatus.Died 
                || _playerModel.RuntimeData.Status == PlayerStatus.Moving)
                return;

            _playerModel.RuntimeData.Status = PlayerStatus.Pressed;
            _bulletPool.Create();
        }

        private void UpdateSize()
        {
            if (_playerModel.RuntimeData.Status == PlayerStatus.Died 
                || _playerModel.RuntimeData.Status == PlayerStatus.Moving)
                return;

            IncreasePressValue();
            
            CalculateDecreaseValue();
            SetCurrentSize();
            
            CalculateColorValue();
            SetCurrentColor();
        }

        private void DeactivateSizeChange()
        {
            if (_playerModel.RuntimeData.Status == PlayerStatus.Died 
                || _playerModel.RuntimeData.Status == PlayerStatus.Moving)
                return;
            
            _playerModel.RuntimeData.Status = PlayerStatus.InActive;
        }

        private void IncreasePressValue()
        {
            _playerModel.RuntimeData.CurrentInputDuration += Time.deltaTime;
        }

        #region Size

        private void CalculateDecreaseValue()
        {
            var inputDuration = _playerModel.RuntimeData.CurrentInputDuration * _playerModel.SettingsData.AnimationSpeed;
            var currentDecreaseValue = _playerModel.SettingsData.SizeDecreaseCurve.Evaluate(inputDuration);
            _playerModel.RuntimeData.CurrentPlayerSize = Vector3.one * currentDecreaseValue;
        }

        private void SetCurrentSize()
        {
            _view.PlayerTransform.localScale = _playerModel.RuntimeData.CurrentPlayerSize;
        }

        #endregion

        #region Color

        private void CalculateColorValue()
        {
            _playerModel.RuntimeData.CurrentPlayerColor = _playerModel.SettingsData.ColorChangeCurve.Evaluate(_playerModel.RuntimeData.CurrentInputDuration);
        }

        private void SetCurrentColor()
        {
            _view.PlayerMesh.material.color = _playerModel.RuntimeData.CurrentPlayerColor;
        }

        #endregion
    }
}
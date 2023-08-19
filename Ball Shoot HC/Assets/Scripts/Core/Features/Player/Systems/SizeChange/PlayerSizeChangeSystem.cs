using System;
using BallShoot.Core.Data.Runtime;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.SizeChange
{
    public class PlayerSizeChangeSystem : IInitializable, IDisposable
    {
        private const int FIRST_CURVE_KEY_INDEX = 0;
        private const int LAST_CURVE_KEY_INDEX = 1;
        
        private readonly IPlayerView _view;
        private readonly PlayerModel _playerModel;
        private readonly CoreRuntimeData _coreRuntimeData;
        private readonly BulletFacade.Factory _bulletPool;

        private float _currentInputDuration = 0f;

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
            _currentInputDuration = 0;
            Debug.Log("STARTED PLAYER");
            _bulletPool.Create();
        }

        private void UpdateSize()
        {
            _currentInputDuration += Time.deltaTime;
            
            CalculateDecreaseValue();
            SetCurrentSize();
            
            CalculateColorValue();
            SetCurrentColor();
            Debug.Log("PRESS PLAYER");
        }

        private void DeactivateSizeChange()
        {
            Debug.Log("DEACTIVATE PLAYER");
        }

        #region Size

        private void CalculateDecreaseValue()
        {
            var inputDuration = _currentInputDuration * _playerModel.SettingsData.AnimationSpeed;
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
            var colorValue = (1f - _playerModel.SettingsData.SizeDecreaseCurve.keys[FIRST_CURVE_KEY_INDEX].value) * _playerModel.RuntimeData.CurrentPlayerSize.x + _playerModel.SettingsData.SizeDecreaseCurve.keys[FIRST_CURVE_KEY_INDEX].value;
            _playerModel.RuntimeData.CurrentPlayerColor = _playerModel.SettingsData.ColorChangeCurve.Evaluate(colorValue);
        }

        private void SetCurrentColor()
        {
            _view.PlayerMesh.material.color = _playerModel.RuntimeData.CurrentPlayerColor;
        }

        #endregion
    }
}
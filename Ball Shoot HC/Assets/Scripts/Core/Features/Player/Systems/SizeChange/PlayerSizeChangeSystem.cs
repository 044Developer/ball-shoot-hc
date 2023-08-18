using BallShoot.Core.Data.Runtime;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using UnityEngine;

namespace BallShoot.Core.Features.Player.Systems.SizeChange
{
    public class PlayerSizeChangeSystem : IPlayerSizeChangeSystem
    {
        private const int FIRST_CURVE_KEY_INDEX = 0;
        private const int LAST_CURVE_KEY_INDEX = 1;
        
        private readonly IPlayerView _view;
        private readonly PlayerModel _playerModel;
        private readonly CoreRuntimeData _coreRuntimeData;

        public PlayerSizeChangeSystem(IPlayerView view, PlayerModel playerModel, CoreRuntimeData coreRuntimeData)
        {
            _view = view;
            _playerModel = playerModel;
            _coreRuntimeData = coreRuntimeData;
        }

        public void ActivateSizeChange()
        {
        }

        public void UpdateSize()
        {
            CalculateDecreaseValue();
            SetCurrentSize();
            
            CalculateColorValue();
            SetCurrentColor();
        }

        public void DeactivateSizeChange()
        {
        }

        #region Size

        private void CalculateDecreaseValue()
        {
            var inputDuration = _coreRuntimeData.InputLength * _playerModel.SettingsData.AnimationSpeed;
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
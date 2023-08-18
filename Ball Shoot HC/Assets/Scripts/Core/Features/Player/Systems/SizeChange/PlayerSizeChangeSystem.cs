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

        public PlayerSizeChangeSystem(IPlayerView view, PlayerModel playerModel)
        {
            _view = view;
            _playerModel = playerModel;
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
            var inputDuration = _playerModel.InputData.InputDuration * _playerModel.AnimationData.AnimationSpeed;
            var currentDecreaseValue = _playerModel.AnimationData.SizeDecreaseCurve.Evaluate(inputDuration);
            _playerModel.StatsData.CurrentPlayerSize = Vector3.one * currentDecreaseValue;
        }

        private void SetCurrentSize()
        {
            _view.PlayerTransform.localScale = _playerModel.StatsData.CurrentPlayerSize;
        }

        #endregion

        #region Color

        private void CalculateColorValue()
        {
            var colorValue = (1f - _playerModel.AnimationData.SizeDecreaseCurve.keys[FIRST_CURVE_KEY_INDEX].value) * _playerModel.StatsData.CurrentPlayerSize.x + _playerModel.AnimationData.SizeDecreaseCurve.keys[FIRST_CURVE_KEY_INDEX].value;
            _playerModel.StatsData.CurrentPlayerColor = _playerModel.AnimationData.ColorChangeCurve.Evaluate(colorValue);
        }

        private void SetCurrentColor()
        {
            _view.PlayerMesh.material.color = _playerModel.StatsData.CurrentPlayerColor;
        }

        #endregion
    }
}
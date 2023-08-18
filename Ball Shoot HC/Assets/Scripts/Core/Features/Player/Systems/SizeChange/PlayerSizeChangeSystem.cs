using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using UnityEngine;

namespace BallShoot.Core.Features.Player.Systems.SizeChange
{
    public interface IPlayerSizeChangeSystem
    {
        void ActivateSizeChange();
        void UpdateSize();
        void DeactivateSizeChange();
    }
    
    public class PlayerSizeChangeSystem : IPlayerSizeChangeSystem
    {
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
        }

        public void DeactivateSizeChange()
        {
        }

        #region Size

        private void CalculateDecreaseValue()
        {
            var currentDecreaseValue = _playerModel.AnimationData.SizeDecreaseCurve.Evaluate(0.5f);
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
            var colorValue = (1f - _playerModel.SettingsData.MinCharacterSize) * currentDecreaseValue 
        }

        private void SetCurrentColor()
        {
            _view.PlayerTransform.localScale = _playerModel.StatsData.CurrentPlayerSize;
        }

        #endregion
    }
}
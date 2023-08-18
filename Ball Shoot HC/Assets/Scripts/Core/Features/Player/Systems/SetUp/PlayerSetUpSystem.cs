using BallShoot.Core.Features.Player.Configs;
using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using BallShoot.Core.MonoModels;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.SetUp
{
    public class PlayerSetUpSystem : IInitializable
    {
        private readonly IPlayerView _view;
        private readonly CoreSettingsModel _coreSettingsModel;
        private readonly PlayerConfiguration _playerConfiguration;
        private readonly PlayerModel _playerModel;

        public PlayerSetUpSystem(
            IPlayerView view,
            CoreSettingsModel coreSettingsModel,
            PlayerConfiguration playerConfiguration,
            PlayerModel playerModel
            )
        {
            _view = view;
            _coreSettingsModel = coreSettingsModel;
            _playerConfiguration = playerConfiguration;
            _playerModel = playerModel;
        }
        
        public void Initialize()
        {
            SetUpSettings();
            
            SetUpRuntimeData();
            
            PositionPlayer();
        }

        private void SetUpSettings()
        {
            _playerModel.SettingsData = new PlayerSettingsData
            (
                animationSpeed: _playerConfiguration.AnimationSpeed,
                sizeDecreaseCurve: _playerConfiguration.PlayerSizeAnimationCurve,
                colorChangeCurve: _playerConfiguration.PlayerColorGradientCurve
            );
        }

        private void SetUpRuntimeData()
        {
            _playerModel.RuntimeData = new PlayerRuntimeData
            (
                PlayerStatus.InActive,
                currentPlayerSize: Vector3.one,
                Color.yellow
            );
        }

        private void PositionPlayer()
        {
            _view.PlayerTransform.position = _coreSettingsModel.SpawnPositions.PlayerSpawnPosition.position;
        }
    }
}
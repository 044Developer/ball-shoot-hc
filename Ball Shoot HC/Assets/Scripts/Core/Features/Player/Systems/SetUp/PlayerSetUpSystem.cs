using BallShoot.Core.Features.Player.Configs;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using BallShoot.Core.MonoModels;
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
            SetUpPlayerStats();
            PositionPlayer();
        }

        private void SetUpPlayerStats()
        {
            _playerModel.AnimationData.AnimationSpeed = _playerConfiguration.AnimationSpeed;
            _playerModel.AnimationData.SizeDecreaseCurve = _playerConfiguration.PlayerSizeAnimationCurve;
            _playerModel.AnimationData.ColorChangeCurve = _playerConfiguration.PlayerColorGradientCurve;
        }

        private void PositionPlayer()
        {
            _view.PlayerTransform.position = _coreSettingsModel.SpawnPositions.PlayerSpawnPosition.position;
        }
    }
}
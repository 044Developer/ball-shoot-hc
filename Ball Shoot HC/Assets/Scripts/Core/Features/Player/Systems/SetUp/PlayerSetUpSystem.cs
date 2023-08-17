using BallShoot.Core.Features.Player.Configs;
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

        public PlayerSetUpSystem(IPlayerView view, CoreSettingsModel coreSettingsModel, PlayerConfiguration playerConfiguration)
        {
            _view = view;
            _coreSettingsModel = coreSettingsModel;
            _playerConfiguration = playerConfiguration;
        }
        
        public void Initialize()
        {
            PositionPlayer();
        }

        private void PositionPlayer()
        {
            _view.PlayerTransform.position = _coreSettingsModel.SpawnPositions.PlayerSpawnPosition.position;
        }
    }
}
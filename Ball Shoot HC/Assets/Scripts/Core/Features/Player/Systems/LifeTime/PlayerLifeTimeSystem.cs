using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.Systems.Destroy;
using BallShoot.Core.Features.Player.View;

namespace BallShoot.Core.Features.Player.Systems.LifeTime
{
    public class PlayerLifeTimeSystem : IPlayerLifeTimeSystem
    {
        private readonly PlayerModel _model;
        private readonly IPlayerView _view;
        private readonly IPlayerDestroySystem _destroySystem;

        public PlayerLifeTimeSystem(PlayerModel model, IPlayerView view, IPlayerDestroySystem destroySystem)
        {
            _model = model;
            _view = view;
            _destroySystem = destroySystem;
        }
        
        public void Tick()
        {
            if (_model.RuntimeData.Status != PlayerStatus.Pressed)
                return;

            if (_view.PlayerTransform.localScale.x <= _model.SettingsData.MinPlayerSize)
            {
                _destroySystem.Die();
            }
        }
    }
}
using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using UnityEngine;

namespace BallShoot.Core.Features.Player.Systems.Jump
{
    public class PlayerJumpSystem : IPlayerJumpSystem
    {
        private readonly PlayerModel _model;
        private readonly IPlayerView _view;

        public PlayerJumpSystem(PlayerModel model, IPlayerView view)
        {
            _model = model;
            _view = view;
        }
        
        public void Tick()
        {
            if (_model.RuntimeData.Status != PlayerStatus.Moving)
                return;

            if (_model.RuntimeData.CurrentJumpInterval < _model.SettingsData.DelayBetweenJumps)
            {
                _model.RuntimeData.CurrentJumpInterval += Time.deltaTime;
            }
            else
            {
                _view.Rigidbody.AddForce(_model.SettingsData.JumpForce, ForceMode.Impulse);
                _model.RuntimeData.CurrentJumpInterval = 0f;
            }
        }
    }
}
using System;
using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.View;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Hud;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.Jump
{
    public class PlayerJumpSystem : IPlayerJumpSystem, IInitializable, IDisposable
    {
        private readonly PlayerModel _model;
        private readonly IPlayerView _view;
        private readonly HudRuntimeData _hudRuntimeData;

        public PlayerJumpSystem(PlayerModel model, IPlayerView view, HudRuntimeData hudRuntimeData)
        {
            _model = model;
            _view = view;
            _hudRuntimeData = hudRuntimeData;
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

        public void Initialize()
        {
            _hudRuntimeData.OnLaunchBallButtonClick += TriggerPlayerMoveBehaviour;
        }

        public void Dispose()
        {
            _hudRuntimeData.OnLaunchBallButtonClick -= TriggerPlayerMoveBehaviour;
        }

        private void TriggerPlayerMoveBehaviour()
        {
            _model.RuntimeData.Status = PlayerStatus.Moving;
        }
    }
}
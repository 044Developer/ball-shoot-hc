using System;
using BallShoot.Core.Data.Types;
using BallShoot.Core.Features.ExitDoor.View;
using BallShoot.Core.Features.Obstacles.Facade;
using BallShoot.Core.Features.Player.View;
using BallShoot.Core.Systems.LevelGamePlay;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Player.Systems.CheckCondition
{
    public class PlayerCheckConditionHandler : IInitializable, IDisposable
    {
        private readonly IPlayerView _view;
        private readonly ILevelGamePlaySystem _levelGamePlaySystem;

        public PlayerCheckConditionHandler(IPlayerView view, ILevelGamePlaySystem levelGamePlaySystem)
        {
            _view = view;
            _levelGamePlaySystem = levelGamePlaySystem;
        }
        
        public void Initialize()
        {
            _view.CollisionHandler.OnCollisionEnterEvent += CheckCollisionEnter;
        }

        public void Dispose()
        {
            _view.CollisionHandler.OnCollisionEnterEvent -= CheckCollisionEnter;
        }

        private void CheckCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ObstacleFacade _))
            {
                _levelGamePlaySystem.ChangeLevelState(LevelStateType.Loose);
                return;
            }

            if (collision.gameObject.TryGetComponent(out ExitDoorView _))
            {
                _levelGamePlaySystem.ChangeLevelState(LevelStateType.Win);
            }
        }
    }
}
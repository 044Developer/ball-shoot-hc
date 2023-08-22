using System;
using BallShoot.Core.Features.ExitDoor.Systems.Animation;
using BallShoot.Core.Features.ExitDoor.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.ExitDoor.Systems.CheckForPlayer
{
    public class CheckForPlayerSystem : IInitializable, IDisposable
    {
        private const string PLAYER_TAG = "Player";
        
        private readonly IExitDoorView _view;
        private readonly IExitDoorAnimationSystem _animationSystem;

        public CheckForPlayerSystem(IExitDoorView view, IExitDoorAnimationSystem animationSystem)
        {
            _view = view;
            _animationSystem = animationSystem;
        }
        
        public void Initialize()
        {
            _view.CollisionHandler.OnTriggerEnterEvent += CheckForClosesElement;
        }

        public void Dispose()
        {
            _view.CollisionHandler.OnTriggerEnterEvent -= CheckForClosesElement;
        }

        private void CheckForClosesElement(Collider collider)
        {
            if (collider.CompareTag(PLAYER_TAG))
            {
                _animationSystem.OpenDoor();
            }
        }
    }
}
using BallShoot.Core.Features.Player.Models;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BallShoot.Core.Features.Player.Systems.PlayerInput
{
    public class EditorInputSystem : IInputSystem
    {
        private const int LMB_INDEX = 0;
        private readonly PlayerModel _playerModel;
        private bool _isTouchedOverUI = false;

        public EditorInputSystem(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }
        
        public void Tick()
        {
            ReadInput();
        }
        
        private void ReadInput()
        {
            if (Input.GetMouseButton(LMB_INDEX))
            {
                ReadMovingInput();
            }

            if (Input.GetMouseButtonUp(LMB_INDEX))
            {
                InputFinished();
            }
        }
        
        private void ReadMovingInput()
        {
            if (Input.GetMouseButtonDown(LMB_INDEX))
            {
                InputStarted();
            }

            if (Input.GetMouseButton(LMB_INDEX))
            {
                ContinueInput();
            }
        }

        private void InputStarted()
        {
            var currentEventSystem = EventSystem.current;
            if (currentEventSystem != null)
            {
                _isTouchedOverUI = currentEventSystem.IsPointerOverGameObject();
            }
        }

        private void ContinueInput()
        {
            if (_isTouchedOverUI)
                return;

            _playerModel.InputData.InputDuration += Time.deltaTime;
        }

        private void InputFinished()
        {
            _isTouchedOverUI = false;
        }
    }
}
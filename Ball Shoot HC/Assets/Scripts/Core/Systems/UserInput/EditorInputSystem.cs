using BallShoot.Core.Data.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BallShoot.Core.Systems.UserInput
{
    public class EditorInputSystem : IInputSystem
    {
        private const int LMB_INDEX = 0;
        private readonly CoreRuntimeData _coreRuntimeData;
        
        private bool _isTouchedOverUI = false;

        public EditorInputSystem(CoreRuntimeData coreRuntimeData)
        {
            _coreRuntimeData = coreRuntimeData;
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
            
            if (_isTouchedOverUI)
                return;
            
            _coreRuntimeData.OnTapStartedEvent?.Invoke();
        }

        private void ContinueInput()
        {
            if (_isTouchedOverUI)
                return;

            _coreRuntimeData.OnTapEvent?.Invoke();
        }

        private void InputFinished()
        {
            _isTouchedOverUI = false;
            
            _coreRuntimeData.OnTapFinishedEvent?.Invoke();
        }
    }
}
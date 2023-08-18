using BallShoot.Core.Data.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BallShoot.Core.Systems.UserInput
{
    public class MobileInputSystem : IInputSystem
    {
        private readonly CoreRuntimeData _coreRuntimeData;
        
        private bool _isTouchedOverUI = false;

        public MobileInputSystem(CoreRuntimeData coreRuntimeData)
        {
            _coreRuntimeData = coreRuntimeData;
        }
        
        public void Tick()
        {
            ReadInput();
        }

        private void ReadInput()
        {
            if (Input.touchCount <= 0)
            {
                return;
            }
            
            CheckInput();
        }

        private void CheckInput()
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    InputStarted(touch);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    ContinueInput();
                    break;
                case TouchPhase.Ended:
                    InputFinished();
                    break;
            }
        }

        private void InputStarted(Touch touch)
        {
            var currentEventSystem = EventSystem.current;
            if (currentEventSystem != null)
            {
                _isTouchedOverUI = currentEventSystem.IsPointerOverGameObject(touch.fingerId);
            }
        }

        private void ContinueInput()
        {
            if (_isTouchedOverUI)
                return;

            _coreRuntimeData.InputLength += Time.deltaTime;
        }

        private void InputFinished()
        {
            _isTouchedOverUI = false;
        }
    }
}
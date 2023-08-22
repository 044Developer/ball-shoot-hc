using Zenject;

namespace BallShoot.Core.Systems.UserInput
{
    public class UserInputSystem : IInitializable
    {
        private readonly MobileInputSystem _mobileInputSystem;
        private readonly EditorInputSystem _editorInputSystem;
        private IInputSystem _inputSystem;

        public UserInputSystem(MobileInputSystem mobileInputSystem, EditorInputSystem editorInputSystem)
        {
            _mobileInputSystem = mobileInputSystem;
            _editorInputSystem = editorInputSystem;
        }
        
        public void Initialize()
        {
#if UNITY_EDITOR
            _inputSystem = _editorInputSystem;
#else
            _inputSystem = _mobileInputSystem;
#endif
        }
        
        public void ReadInput()
        {
            _inputSystem.Tick();
        }
    }
}
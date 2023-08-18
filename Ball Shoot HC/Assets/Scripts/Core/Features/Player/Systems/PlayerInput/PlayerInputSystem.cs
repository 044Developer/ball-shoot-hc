using Zenject;

namespace BallShoot.Core.Features.Player.Systems.PlayerInput
{
    public class PlayerInputSystem : IInitializable
    {
        private readonly MobileInputSystem _mobileInputSystem = null;
        private readonly EditorInputSystem _editorInputSystem = null;
        private IInputSystem _inputSystem = null;

        public PlayerInputSystem(MobileInputSystem mobileInputSystem, EditorInputSystem editorInputSystem)
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
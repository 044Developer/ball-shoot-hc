using BallShoot.Core.Systems.UserInput;
using Zenject;

namespace BallShoot.Core.Systems.Update
{
    public class CoreUpdateSystem : ITickable
    {
        private readonly UserInputSystem _inputSystem;

        public CoreUpdateSystem(UserInputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
        
        public void Tick()
        {
            _inputSystem.ReadInput();
        }
    }
}
using BallShoot.Core.Data.Types;
using BallShoot.Core.Systems.LevelGamePlay;
using BallShoot.Core.Systems.UserInput;
using Zenject;

namespace BallShoot.Core.Systems.Update
{
    public class CoreUpdateSystem : ITickable
    {
        private readonly UserInputSystem _inputSystem;
        private readonly ILevelGamePlaySystem _levelGamePlaySystem;

        public CoreUpdateSystem(UserInputSystem inputSystem, ILevelGamePlaySystem levelGamePlaySystem)
        {
            _inputSystem = inputSystem;
            _levelGamePlaySystem = levelGamePlaySystem;
        }
        
        public void Tick()
        {
            if (_levelGamePlaySystem.CurrentLevelState != LevelStateType.Play)
                return;

            _inputSystem.ReadInput();
        }
    }
}
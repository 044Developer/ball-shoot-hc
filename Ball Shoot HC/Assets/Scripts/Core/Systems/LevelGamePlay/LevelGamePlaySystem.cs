using BallShoot.Core.Data.Types;
using BallShoot.Core.Systems.LevelLoose;
using BallShoot.Core.Systems.LevelRestart;
using BallShoot.Core.Systems.LevelWin;

namespace BallShoot.Core.Systems.LevelGamePlay
{
    public class LevelGamePlaySystem : ILevelGamePlaySystem
    {
        private readonly ILevelRestartSystem _restartSystem;
        private readonly ILevelWinSystem _levelWinSystem;
        private readonly ILevelLooseSystem _levelLooseSystem;

        public LevelGamePlaySystem(
            ILevelRestartSystem restartSystem,
            ILevelWinSystem levelWinSystem,
            ILevelLooseSystem levelLooseSystem)
        {
            _restartSystem = restartSystem;
            _levelWinSystem = levelWinSystem;
            _levelLooseSystem = levelLooseSystem;
        }
        
        public void ChangeLevelState(LevelStateType newState)
        {
            switch (newState)
            {
                case LevelStateType.Restart:
                    _restartSystem.RestartLevel();
                    break;
                case LevelStateType.Win:
                    _levelWinSystem.ProceedLevelWin();
                    break;
                case LevelStateType.Loose:
                    _levelLooseSystem.ProceedLevelLose();
                    break;
            }
        }
    }
}
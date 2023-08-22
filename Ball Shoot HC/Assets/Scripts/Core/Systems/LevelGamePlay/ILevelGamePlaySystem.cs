using BallShoot.Core.Data.Types;

namespace BallShoot.Core.Systems.LevelGamePlay
{
    public interface ILevelGamePlaySystem
    {
        public LevelStateType CurrentLevelState { get; }
        void ChangeLevelState(LevelStateType newState);
    }
}
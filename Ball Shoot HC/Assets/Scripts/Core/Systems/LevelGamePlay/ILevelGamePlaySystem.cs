using BallShoot.Core.Data.Types;

namespace BallShoot.Core.Systems.LevelGamePlay
{
    public interface ILevelGamePlaySystem
    {
        void ChangeLevelState(LevelStateType newState);
    }
}
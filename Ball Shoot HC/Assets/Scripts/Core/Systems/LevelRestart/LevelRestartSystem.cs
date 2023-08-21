namespace BallShoot.Core.Systems.LevelRestart
{
    public class LevelRestartSystem : ILevelRestartSystem
    {
        public void RestartLevel()
        {
        }
    }

    public interface ILevelRestartSystem
    {
        void RestartLevel();
    }
}
using BallShoot.Infrastructure.Modules.SceneLoader;

namespace BallShoot.Core.Systems.LevelRestart
{
    public class LevelRestartSystem : ILevelRestartSystem
    {
        private readonly ISceneLoaderModule _sceneLoaderModule;

        public LevelRestartSystem(ISceneLoaderModule sceneLoaderModule)
        {
            _sceneLoaderModule = sceneLoaderModule;
        }
        public void RestartLevel()
        {
            _sceneLoaderModule.ReLoadCurrent();
        }
    }
}
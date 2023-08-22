using BallShoot.Infrastructure.Modules.SceneLoader;

namespace BallShoot.Core.Systems.LevelWin
{
    public class LevelWinSystem : ILevelWinSystem
    {
        private readonly ISceneLoaderModule _sceneLoaderModule;

        public LevelWinSystem(ISceneLoaderModule sceneLoaderModule)
        {
            _sceneLoaderModule = sceneLoaderModule;
        }
        
        public void ProceedLevelWin()
        {
            _sceneLoaderModule.ReLoadCurrent();
        }
    }
}
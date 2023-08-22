using BallShoot.Infrastructure.Modules.SceneLoader;

namespace BallShoot.Core.Systems.LevelLoose
{
    public class LevelLooseSystem : ILevelLooseSystem
    {
        private readonly ISceneLoaderModule _sceneLoaderModule;

        public LevelLooseSystem(ISceneLoaderModule sceneLoaderModule)
        {
            _sceneLoaderModule = sceneLoaderModule;
        }
        
        public void ProceedLevelLose()
        {
            _sceneLoaderModule.ReLoadCurrent();
        }
    }
}
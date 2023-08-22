using BallShoot.Infrastructure.Data;
using BallShoot.Infrastructure.Modules.SceneLoader;
using UnityEngine.SceneManagement;

namespace BallShoot.Infrastructure.Bootstrap
{
    public class Game : IGame
    {
        private readonly ISceneLoaderModule _sceneLoaderModule;

        public Game(ISceneLoaderModule sceneLoaderModule)
        {
            _sceneLoaderModule = sceneLoaderModule;
        }
        
        public void StartApplication()
        {
            _sceneLoaderModule.Load(SceneType.Core, LoadSceneMode.Additive);
        }

        public void QuitApplication()
        {
        }
    }
}
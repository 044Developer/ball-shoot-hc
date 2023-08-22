using BallShoot.Infrastructure.Data;
using BallShoot.Infrastructure.Modules.SceneLoader;
using BallShoot.Infrastructure.Modules.UserInterface.Data;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loading;
using BallShoot.Infrastructure.Modules.UserInterface.Screens;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

namespace BallShoot.Infrastructure.Bootstrap
{
    public class Game : IGame
    {
        private readonly ISceneLoaderModule _sceneLoaderModule;
        private readonly IScreensModule _screensModule;

        public Game(ISceneLoaderModule sceneLoaderModule, IScreensModule screensModule)
        {
            _sceneLoaderModule = sceneLoaderModule;
            _screensModule = screensModule;
        }
        
        public void StartApplication()
        {
            Application.targetFrameRate = 30;
            
            _screensModule.OpenScreen<LoadingScreen>(UIType.Loading);
            _sceneLoaderModule.Load(SceneType.Core, LoadSceneMode.Additive);
        }

        public void QuitApplication()
        {
        }
    }
}
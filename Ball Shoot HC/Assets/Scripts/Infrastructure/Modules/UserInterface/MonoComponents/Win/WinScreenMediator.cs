using BallShoot.Infrastructure.Data;
using BallShoot.Infrastructure.Modules.SceneLoader;
using BallShoot.Infrastructure.Modules.UserInterface.Data;
using BallShoot.Infrastructure.Modules.UserInterface.Hud;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loading;
using BallShoot.Infrastructure.Modules.UserInterface.Screens;
using UnityEngine.SceneManagement;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Win
{
    public class WinScreenMediator
    {
        private readonly ISceneLoaderModule _sceneLoaderModule;
        private readonly IScreensModule _screensModule;
        private readonly IHudModule _hudModule;
        private WinScreenViewModel _viewModel;

        public WinScreenMediator(ISceneLoaderModule sceneLoaderModule, IScreensModule screensModule, IHudModule hudModule)
        {
            _sceneLoaderModule = sceneLoaderModule;
            _screensModule = screensModule;
            _hudModule = hudModule;
        }
        
        public void SetModel(WinScreenViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void OnOpenScreen()
        {
            _hudModule.CloseHud(UIType.Hud, true);
        }

        public void OnRestartButtonClick()
        {
            _sceneLoaderModule.Load(SceneType.Core, LoadSceneMode.Additive);
            
            _screensModule.CloseScreen(UIType.Win, true);
            
            _screensModule.OpenScreen<LoadingScreen>(UIType.Loading);
        }
    }
}
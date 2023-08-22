using BallShoot.Infrastructure.Modules.UserInterface.Data;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Win;
using BallShoot.Infrastructure.Modules.UserInterface.Screens;

namespace BallShoot.Core.Systems.LevelWin
{
    public class LevelWinSystem : ILevelWinSystem
    {
        private readonly IScreensModule _screensModule;

        public LevelWinSystem(IScreensModule screensModule)
        {
            _screensModule = screensModule;
        }
        
        public void ProceedLevelWin()
        {
            _screensModule.OpenScreen<WinScreen>(UIType.Win);
        }
    }
}
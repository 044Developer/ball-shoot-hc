using BallShoot.Infrastructure.Modules.UserInterface.Data;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loose;
using BallShoot.Infrastructure.Modules.UserInterface.Screens;

namespace BallShoot.Core.Systems.LevelLoose
{
    public class LevelLooseSystem : ILevelLooseSystem
    {
        private readonly IScreensModule _screensModule;

        public LevelLooseSystem(IScreensModule screensModule)
        {
            _screensModule = screensModule;
        }
        
        public void ProceedLevelLose()
        {
            _screensModule.OpenScreen<LooseScreen>(UIType.Loose);
        }
    }
}
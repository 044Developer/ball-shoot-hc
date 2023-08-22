using System;
using BallShoot.Core.Data.Types;
using BallShoot.Core.Systems.LevelLoose;
using BallShoot.Core.Systems.LevelWin;
using BallShoot.Infrastructure.Modules.UserInterface.Data;
using BallShoot.Infrastructure.Modules.UserInterface.Hud;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Hud;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loading;
using Zenject;

namespace BallShoot.Core.Systems.LevelGamePlay
{
    public class LevelGamePlaySystem : ILevelGamePlaySystem, IInitializable, IDisposable
    {
        private readonly ILevelWinSystem _levelWinSystem;
        private readonly ILevelLooseSystem _levelLooseSystem;
        private readonly LoadingScreenRuntimeData _loadingScreenRuntimeData;
        private readonly IHudModule _hudModule;

        public LevelStateType CurrentLevelState { get; private set; }

        public LevelGamePlaySystem(
            ILevelWinSystem levelWinSystem,
            ILevelLooseSystem levelLooseSystem, 
            LoadingScreenRuntimeData loadingScreenRuntimeData,
            IHudModule hudModule)
        {
            _levelWinSystem = levelWinSystem;
            _levelLooseSystem = levelLooseSystem;
            _loadingScreenRuntimeData = loadingScreenRuntimeData;
            _hudModule = hudModule;
        }
        
        public void ChangeLevelState(LevelStateType newState)
        {
            if (CurrentLevelState == newState)
                return;

            switch (newState)
            {
                case LevelStateType.Win:
                    _levelWinSystem.ProceedLevelWin();
                    break;
                case LevelStateType.Loose:
                    _levelLooseSystem.ProceedLevelLose();
                    break;
            }

            CurrentLevelState = newState;
        }

        public void Initialize()
        {
            _loadingScreenRuntimeData.OnLoadingAnimationEnd += OnLoadingScreenAnimationEnd;

            ChangeLevelState(LevelStateType.None);
        }

        public void Dispose()
        {
            _loadingScreenRuntimeData.OnLoadingAnimationEnd -= OnLoadingScreenAnimationEnd;
        }

        private void OnLoadingScreenAnimationEnd()
        {
            ChangeLevelState(LevelStateType.Play);
            
            _hudModule.OpenHud<HudScreen>(UIType.Hud);
        }
    }
}
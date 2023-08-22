using BallShoot.Infrastructure.Modules.UserInterface.Container;
using BallShoot.Infrastructure.Modules.UserInterface.Hud;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Hud;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loading;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loose;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Root;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Win;
using BallShoot.Infrastructure.Modules.UserInterface.Screens;
using Zenject;

namespace BallShoot.Infrastructure.Installers
{
    public class UIRootInstaller : MonoInstaller
    {
        private const string ROOT_PREFAB_NAME = "Prefabs/UI/[====UserInterface====]";
        
        public override void InstallBindings()
        {
            BindUIRoot();

            BindRuntimeData();

            BindMediators();
            
            BindModules();
        }

        private void BindUIRoot()
        {
            Container
                .Bind<IUIRoot>()
                .To<UIRoot>()
                .FromComponentInNewPrefabResource(ROOT_PREFAB_NAME)
                .AsSingle()
                .NonLazy();
        }

        private void BindRuntimeData()
        {
            Container
                .Bind<LoadingScreenRuntimeData>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<HudRuntimeData>()
                .AsSingle()
                .NonLazy();
        }

        private void BindMediators()
        {
            Container
                .Bind<LoadingScreenMediator>()
                .AsTransient();
            
            Container
                .Bind<HudScreenMediator>()
                .AsTransient();
            
            Container
                .Bind<WinScreenMediator>()
                .AsTransient();
            
            Container
                .Bind<LooseScreenMediator>()
                .AsTransient();
        }

        private void BindModules()
        {
            Container
                .Bind<IUIPathContainer>()
                .To<UIPathContainer>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IHudModule>()
                .To<HudModule>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IScreensModule>()
                .To<ScreensModule>()
                .AsSingle()
                .NonLazy();
        }
    }
}
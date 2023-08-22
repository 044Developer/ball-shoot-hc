using BallShoot.Infrastructure.Modules.UserInterface.Container;
using BallShoot.Infrastructure.Modules.UserInterface.Hud;
using BallShoot.Infrastructure.Modules.UserInterface.Screens;
using Zenject;

namespace BallShoot.Infrastructure.Installers
{
    public class UIRootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindUIRoot();
            
            BindModules();
        }

        private void BindUIRoot()
        {
            Container
                .Bind<IUIRoot>()
                .To<UIRoot>()
                .FromComponentInNewPrefabResource("Prefabs/UI/[====UserInterface====]")
                .AsSingle()
                .NonLazy();;
        }

        private void BindModules()
        {
            Container
                .BindInterfacesAndSelfTo<UIPathContainer>()
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
using BallShoot.Core.Features.ExitDoor.Model;
using BallShoot.Core.Features.ExitDoor.Systems.Animation;
using BallShoot.Core.Features.ExitDoor.Systems.SetUp;
using Zenject;

namespace BallShoot.Core.Features.ExitDoor.Binder
{
    public class ExitDoorInstaller : Installer<ExitDoorInstaller>
    {
        public override void InstallBindings()
        {
            BindModels();

            BindSystems();
        }

        private void BindModels()
        {
            Container
                .Bind<ExitDoorModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<ExitDoorSetUpSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<IExitDoorAnimationSystem>()
                .To<ExitDoorAnimationSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}
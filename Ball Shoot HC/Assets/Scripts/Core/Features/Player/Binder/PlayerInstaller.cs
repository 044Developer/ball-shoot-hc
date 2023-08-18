using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.Systems.PlayerUpdate;
using BallShoot.Core.Features.Player.Systems.SetUp;
using BallShoot.Core.Features.Player.Systems.SizeChange;
using Zenject;

namespace BallShoot.Core.Features.Player.Binder
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            BindModels();

            BindSystems();
        }

        private void BindModels()
        {
            Container
                .Bind<PlayerModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerSetUpSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IPlayerSizeChangeSystem>()
                .To<PlayerSizeChangeSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerUpdateSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}
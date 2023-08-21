using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Player.Systems.Destroy;
using BallShoot.Core.Features.Player.Systems.Jump;
using BallShoot.Core.Features.Player.Systems.LifeTime;
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
                .BindInterfacesAndSelfTo<PlayerSizeChangeSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IPlayerLifeTimeSystem>()
                .To<PlayerLifeTimeSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IPlayerDestroySystem>()
                .To<PlayerDestroySystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IPlayerJumpSystem>()
                .To<PlayerJumpSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerUpdateSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}
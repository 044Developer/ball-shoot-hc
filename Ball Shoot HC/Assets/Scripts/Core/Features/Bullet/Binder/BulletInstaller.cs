using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.Systems.DealDamage;
using BallShoot.Core.Features.Bullet.Systems.Fly;
using BallShoot.Core.Features.Bullet.Systems.Launch;
using BallShoot.Core.Features.Bullet.Systems.SetUp;
using BallShoot.Core.Features.Bullet.Systems.SizeChange;
using BallShoot.Core.Features.Bullet.Systems.Update;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Binder
{
    public class BulletInstaller : Installer<BulletInstaller>
    {
        public override void InstallBindings()
        {
            BindModels();

            BindSystems();
        }

        private void BindModels()
        {
            Container
                .Bind<BulletModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<BulletSetUpSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<BulletChangeSizeSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBulletLaunchSystem>()
                .To<BulletLaunchSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBulletFlySystem>()
                .To<BulletFlySystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBulletDealDamageSystem>()
                .To<BulletDealDamageSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<BulletUpdateSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}
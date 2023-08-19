using BallShoot.Core.Features.Bullet.Model;
using BallShoot.Core.Features.Bullet.Systems.DealDamage;
using BallShoot.Core.Features.Bullet.Systems.Destroy;
using BallShoot.Core.Features.Bullet.Systems.Fly;
using BallShoot.Core.Features.Bullet.Systems.LifeTime;
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
                .AsSingle();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<BulletSetUpSystem>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BulletChangeSizeSystem>()
                .AsSingle();

            Container
                .Bind<IBulletFlySystem>()
                .To<BulletFlySystem>()
                .AsSingle();

            Container
                .Bind<IBulletDestroySystem>()
                .To<BulletDestroySystem>()
                .AsSingle();

            Container
                .Bind<IBulletLifeTimeSystem>()
                .To<BulletLifeTimeSystem>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BulletDealDamageSystem>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<BulletUpdateSystem>()
                .AsSingle()
            ;
        }
    }
}
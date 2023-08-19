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
                .AsTransient();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<BulletSetUpSystem>()
                .AsTransient();

            Container
                .BindInterfacesAndSelfTo<BulletChangeSizeSystem>()
                .AsTransient();

            Container
                .Bind<IBulletFlySystem>()
                .To<BulletFlySystem>()
                .AsTransient();

            Container
                .Bind<IBulletDestroySystem>()
                .To<BulletDestroySystem>()
                .AsTransient();

            Container
                .Bind<IBulletLifeTimeSystem>()
                .To<BulletLifeTimeSystem>()
                .AsTransient();

            Container
                .Bind<IBulletDealDamageSystem>()
                .To<BulletDealDamageSystem>()
                .AsTransient();
            
            Container
                .BindInterfacesAndSelfTo<BulletUpdateSystem>()
                .AsTransient()
            ;
        }
    }
}
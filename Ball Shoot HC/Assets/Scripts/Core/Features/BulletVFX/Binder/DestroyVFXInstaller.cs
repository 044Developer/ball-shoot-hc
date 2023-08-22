using BallShoot.Core.Features.Bullet.Systems.SetUp;
using BallShoot.Core.Features.BulletVFX.Model;
using BallShoot.Core.Features.BulletVFX.Systems.LifeTime;
using BallShoot.Core.Features.BulletVFX.Systems.SetUp;
using BallShoot.Core.Features.BulletVFX.Systems.Update;
using Zenject;

namespace BallShoot.Core.Features.BulletVFX.Binder
{
    public class DestroyVFXInstaller : Installer<DestroyVFXInstaller>
    {
        public override void InstallBindings()
        {
            BindModels();
            BindSystems();
        }

        private void BindModels()
        {
            Container
                .Bind<DestroyVFXModel>()
                .AsSingle();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<DestroyVFXSetUpSystem>()
                .AsSingle();
            
            Container
                .Bind<IDestroyVFXLifeTimeSystem>()
                .To<DestroyVFXLifeTimeSystem>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<DestroyVFXUpdateSystem>()
                .AsSingle();
        }
    }
}
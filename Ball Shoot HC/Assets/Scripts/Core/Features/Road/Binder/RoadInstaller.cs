using BallShoot.Core.Features.Road.Model;
using BallShoot.Core.Features.Road.Systems.SetUp;
using BallShoot.Core.Features.Road.Systems.SizeChange;
using Zenject;

namespace BallShoot.Core.Features.Road.Binder
{
    public class RoadInstaller : Installer<RoadInstaller>
    {
        public override void InstallBindings()
        {
            BindModel();
            
            BindSystems();
        }

        private void BindModel()
        {
            Container
                .Bind<RoadModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<RoadSetUpSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<RoadSizeChangeSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}
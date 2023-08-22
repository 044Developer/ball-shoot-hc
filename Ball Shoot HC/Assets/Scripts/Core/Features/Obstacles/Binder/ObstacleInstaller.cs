using BallShoot.Core.Features.Obstacles.Model;
using BallShoot.Core.Features.Obstacles.Systems.Animation;
using BallShoot.Core.Features.Obstacles.Systems.LifeTime;
using BallShoot.Core.Features.Obstacles.Systems.SetUp;
using BallShoot.Core.Features.Obstacles.Systems.Update;
using Zenject;

namespace BallShoot.Core.Features.Obstacles.Binder
{
    public class ObstacleInstaller : Installer<ObstacleInstaller>
    {
        public override void InstallBindings()
        {
            BindModels();
            
            BindSystems();
        }

        private void BindModels()
        {
            Container
                .Bind<ObstacleModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<ObstacleSetUpSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IObstacleLifeTimeSystem>()
                .To<ObstacleLifeTimeSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IObstacleAnimationSystem>()
                .To<ObstacleAnimationSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<ObstacleUpdateSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}
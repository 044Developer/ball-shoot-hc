using BallShoot.Infrastructure.Bootstrap;
using BallShoot.Infrastructure.Modules.AssetProvider;
using BallShoot.Infrastructure.Modules.AssetProvider.Implementation;
using BallShoot.Infrastructure.Modules.CoroutineRunner;
using BallShoot.Infrastructure.Modules.CustomFactory;
using BallShoot.Infrastructure.Modules.CustomFactory.Implementation;
using BallShoot.Infrastructure.Modules.SceneLoader;
using Zenject;

namespace BallShoot.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEntryPoint();
            
            BindModules();
        }

        private void BindEntryPoint()
        {
            Container
                .Bind<IGame>()
                .To<Game>()
                .AsSingle()
                .NonLazy();
        }

        private void BindModules()
        {
            BindCoroutineRunner();
            
            BindSceneLoader();

            BindAssetProvider();

            BindCustomFactory();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoaderModule>()
                .To<SceneLoaderModule>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProviderModule>()
                .To<AssetProviderModule>()
                .AsSingle();
        }

        private void BindCustomFactory()
        {
            Container
                .Bind<ICustomFactoryModule>()
                .To<CustomFactoryModule>()
                .AsSingle();
        }
    }
}
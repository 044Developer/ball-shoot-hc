using BallShoot.Infrastructure.Bootstrap;
using BallShoot.Infrastructure.Modules.CoroutineRunner;
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
    }
}
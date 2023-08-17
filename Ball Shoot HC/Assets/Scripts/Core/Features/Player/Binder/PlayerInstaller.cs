using BallShoot.Core.Features.Player.Systems.SetUp;
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
            
        }

        private void BindSystems()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerSetUpSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}
using BallShoot.Core.Data.Runtime;
using BallShoot.Core.Features.Bullet.Binder;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.Bullet.View;
using BallShoot.Core.Features.ExitDoor.Binder;
using BallShoot.Core.Features.ExitDoor.View;
using BallShoot.Core.Features.Player.Binder;
using BallShoot.Core.Features.Player.View;
using BallShoot.Core.MonoModels;
using BallShoot.Core.Systems.Update;
using BallShoot.Core.Systems.UserInput;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.SceneInstallers
{
    public class CoreSceneInstaller : MonoInstaller
    {
        [SerializeField] private CoreSceneModel _coreSceneModel;
        [SerializeField] private CoreSettingsModel _coreSettingsModel;
        
        public override void InstallBindings()
        {
            BindData();
            
            BindModels();

            BindSystems();
            
            BindFeatures();
        }

        private void BindData()
        {
            Container
                .Bind<CoreRuntimeData>()
                .AsSingle()
                .NonLazy();
        }

        private void BindModels()
        {
            Container
                .BindInstance(_coreSceneModel)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInstance(_coreSettingsModel)
                .AsSingle()
                .NonLazy();
        }

        private void BindSystems()
        {
            Container
                .Bind<MobileInputSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<EditorInputSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<UserInputSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CoreUpdateSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindFeatures()
        {
            BindExitDoor();

            BindBullet();
            
            BindPlayer();
        }

        private void BindExitDoor()
        {
            Container
                .Bind<IExitDoorView>()
                .To<ExitDoorView>()
                .FromSubContainerResolve()
                .ByNewPrefabInstaller<ExitDoorInstaller>(_coreSettingsModel.PrefabSettings.ExitDoorPrefab)
                .UnderTransform(_coreSceneModel.DynamicPrefabParent)
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayer()
        {
            Container
                .Bind<IPlayerView>()
                .To<PlayerView>()
                .FromSubContainerResolve()
                .ByNewPrefabInstaller<PlayerInstaller>(_coreSettingsModel.PrefabSettings.PlayerPrefab)
                .UnderTransform(_coreSceneModel.DynamicPrefabParent)
                .AsSingle()
                .NonLazy();
        }

        private void BindBullet()
        {
            Container
                .BindFactory<BulletFacade, BulletFacade.Factory>()
                .FromPoolableMemoryPool<BulletFacade, BulletFacadePool>(binder 
                    => binder
                        .WithInitialSize(5)
                        .FromSubContainerResolve()
                        .ByNewPrefabInstaller<BulletInstaller>(_coreSettingsModel.PrefabSettings.BulletPrefab)
                        .UnderTransform(_coreSceneModel.DynamicPrefabParent)
                        .AsCached());
        }
        
        class BulletFacadePool : MonoPoolableMemoryPool<IMemoryPool, BulletFacade>
        {
        }
    }
}
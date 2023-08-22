using BallShoot.Core.Features.Bullet.Binder;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.BulletVFX.Binder;
using BallShoot.Core.Features.BulletVFX.Facade;
using BallShoot.Core.Features.ExitDoor.Binder;
using BallShoot.Core.Features.ExitDoor.View;
using BallShoot.Core.Features.Obstacles.Binder;
using BallShoot.Core.Features.Obstacles.Facade;
using BallShoot.Core.Features.Player.Binder;
using BallShoot.Core.Features.Player.View;
using BallShoot.Core.Features.Road.Binder;
using BallShoot.Core.Features.Road.View;
using BallShoot.Core.Systems.LevelGamePlay;
using BallShoot.Core.Systems.LevelLoose;
using BallShoot.Core.Systems.LevelRestart;
using BallShoot.Core.Systems.LevelWin;
using BallShoot.Core.Systems.ObstaclesSpawn;
using BallShoot.Core.Systems.Update;
using BallShoot.Core.Systems.UserInput;
using BallShoot.Core.MonoModels;
using BallShoot.Core.Data.Runtime;
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
            BindLevel();
            
            BindExitDoor();

            BindRoad();

            BindBullet();

            BindDestroyVFX();
            
            BindPlayer();

            BindObstacles();
        }

        private void BindLevel()
        {
            Container
                .Bind<ILevelRestartSystem>()
                .To<LevelRestartSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ILevelLooseSystem>()
                .To<LevelLooseSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ILevelWinSystem>()
                .To<LevelWinSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ILevelGamePlaySystem>()
                .To<LevelGamePlaySystem>()
                .AsSingle()
                .NonLazy();
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

        private void BindRoad()
        {
            Container
                .Bind<IRoadView>()
                .To<RoadView>()
                .FromSubContainerResolve()
                .ByNewPrefabInstaller<RoadInstaller>(_coreSettingsModel.PrefabSettings.RoadPrefab)
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
                        .UnderTransform(_coreSceneModel.DynamicBulletsPrefabParent)
                        .AsTransient());
        }

        private void BindDestroyVFX()
        {
            Container
                .BindFactory<Vector3, float, DestroyVFXFacade, DestroyVFXFacade.Factory>()
                .FromPoolableMemoryPool<Vector3, float, DestroyVFXFacade, DestroyVFXFacadePool>(binder 
                    => binder
                        .WithInitialSize(5)
                        .FromSubContainerResolve()
                        .ByNewPrefabInstaller<DestroyVFXInstaller>(_coreSettingsModel.PrefabSettings.DestroyVFXPrefab)
                        .UnderTransform(_coreSceneModel.DynamicVFXPrefabParent)
                        .AsTransient());
        }

        private void BindObstacles()
        {
            Container
                .BindInterfacesAndSelfTo<ObstaclesSpawnSystem>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindFactory<Vector3, ObstacleFacade, ObstacleFacade.Factory>()
                .FromPoolableMemoryPool<Vector3, ObstacleFacade, ObstacleFacadePool>(binder 
                    => binder
                        .WithInitialSize(30)
                        .FromSubContainerResolve()
                        .ByNewPrefabInstaller<ObstacleInstaller>(ChooseFooPrefab)
                        .UnderTransform(_coreSceneModel.DynamicObstaclesPrefabParent)
                        .AsTransient());
        }

        Object ChooseFooPrefab(InjectContext context)
        {
            return _coreSettingsModel.PrefabSettings.ObstacleList[Random.Range(0, _coreSettingsModel.PrefabSettings.ObstacleList.Count)];
        }

        class BulletFacadePool : MonoPoolableMemoryPool<IMemoryPool, BulletFacade>
        {
        }
        
        class DestroyVFXFacadePool : MonoPoolableMemoryPool<Vector3, float, IMemoryPool, DestroyVFXFacade>
        {
        }
        
        class ObstacleFacadePool : MonoPoolableMemoryPool<Vector3, IMemoryPool, ObstacleFacade>
        {
        }
    }
}
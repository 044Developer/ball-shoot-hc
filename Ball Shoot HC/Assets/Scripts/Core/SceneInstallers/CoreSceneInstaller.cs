using BallShoot.Core.Features.ExitDoor.Binder;
using BallShoot.Core.Features.ExitDoor.View;
using BallShoot.Core.Features.Player.Binder;
using BallShoot.Core.Features.Player.View;
using BallShoot.Core.MonoModels;
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
            BindModels();
            
            BindExitDoor();
            
            BindPlayer();
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
    }
}
using BallShoot.Core.Features.Bullet.Configs;
using BallShoot.Core.Features.BulletVFX.Configuration;
using BallShoot.Core.Features.ExitDoor.Configs;
using BallShoot.Core.Features.Obstacles.Configuration;
using BallShoot.Core.Features.Player.Configs;
using BallShoot.Core.Features.Road.Configuration;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.SceneInstallers
{
    [CreateAssetMenu(fileName = "CoreSceneScriptableObjectInstaller", menuName = "Installers/CoreSceneScriptableObjectInstaller")]
    public class CoreSceneScriptableObjectInstaller : ScriptableObjectInstaller<CoreSceneScriptableObjectInstaller>
    {
        [SerializeField] private ExitDoorConfiguration _exitDoorConfiguration;
        [SerializeField] private PlayerConfiguration _playerConfiguration;
        [SerializeField] private BulletConfiguration _bulletConfiguration;
        [SerializeField] private DestroyVFXConfiguration _vfxConfiguration;
        [SerializeField] private ObstacleConfiguration _obstacleConfiguration;
        [SerializeField] private RoadConfiguration _roadConfiguration;
    
        public override void InstallBindings()
        {
            BindConfigs();
        }

        private void BindConfigs()
        {
            Container
                .BindInstance(_exitDoorConfiguration)
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInstance(_playerConfiguration)
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInstance(_bulletConfiguration)
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInstance(_vfxConfiguration)
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInstance(_obstacleConfiguration)
                .AsSingle()
                .NonLazy();
        
            Container
                .BindInstance(_roadConfiguration)
                .AsSingle()
                .NonLazy();
        }
    }
}
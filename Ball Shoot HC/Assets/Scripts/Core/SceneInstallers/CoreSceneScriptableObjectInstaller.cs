using BallShoot.Core.Features.Bullet.Configs;
using BallShoot.Core.Features.ExitDoor.Configs;
using BallShoot.Core.Features.Player.Configs;
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
        }
    }
}
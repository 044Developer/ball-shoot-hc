using BallShoot.Core.Features.ExitDoor.Configs;
using BallShoot.Core.Features.Player.Configs;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "CoreSceneScriptableObjectInstaller", menuName = "Installers/CoreSceneScriptableObjectInstaller")]
public class CoreSceneScriptableObjectInstaller : ScriptableObjectInstaller<CoreSceneScriptableObjectInstaller>
{
    [SerializeField] private ExitDoorConfiguration _exitDoorConfiguration;
    [SerializeField] private PlayerConfiguration _playerConfiguration;
    
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
    }
}
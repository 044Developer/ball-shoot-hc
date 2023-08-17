using BallShoot.Core.Features.ExitDoor.Configs;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "CoreSceneScriptableObjectInstaller", menuName = "Installers/CoreSceneScriptableObjectInstaller")]
public class CoreSceneScriptableObjectInstaller : ScriptableObjectInstaller<CoreSceneScriptableObjectInstaller>
{
    [SerializeField] private ExitDoorConfiguration _exitDoorConfiguration;
    
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
    }
}
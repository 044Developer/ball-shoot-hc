using BallShoot.Core.SceneInstallers;
using BallShoot.Infrastructure.Configurations;
using UnityEngine;
using Zenject;

namespace BallShoot.Infrastructure.Installers
{
    [CreateAssetMenu(fileName = "ProjectScriptableObjectInstaller", menuName = "Installers/ProjectScriptableObjectInstaller")]
    public class ProjectScriptableObjectInstaller : ScriptableObjectInstaller<CoreSceneScriptableObjectInstaller>
    {
        [SerializeField] private ProjectSceneConfiguration _sceneConfiguration;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(_sceneConfiguration)
                .AsSingle()
                .NonLazy();
        }
    }
}
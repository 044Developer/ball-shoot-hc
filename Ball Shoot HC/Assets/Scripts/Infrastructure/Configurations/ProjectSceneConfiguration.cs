using System.Collections.Generic;
using BallShoot.Infrastructure.Models;
using UnityEngine;

namespace BallShoot.Infrastructure.Configurations
{
    [CreateAssetMenu(menuName = "Configs/Infrastructure/Scene", fileName = "scene_configuration")]
    public class ProjectSceneConfiguration : ScriptableObject
    {
        [SerializeField] private List<SceneModel> _sceneModels;

        public List<SceneModel> SceneModels => _sceneModels;
    }
}
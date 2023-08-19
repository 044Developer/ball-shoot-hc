using UnityEngine;

namespace BallShoot.Core.MonoModels
{
    public class CoreSceneModel : MonoBehaviour
    {
        [Header("Common")]
        [SerializeField] private Transform _dynamicPrefabParent;
        
        [Header("Bullets")]
        [SerializeField] private Transform _dynamicBulletsPrefabParent;
        
        [Header("VFX")]
        [SerializeField] private Transform _dynamicVFXPrefabParent;
        
        [Header("Obstacles")]
        [SerializeField] private Transform _dynamicObstaclesPrefabParent;

        public Transform DynamicPrefabParent => _dynamicPrefabParent;
        public Transform DynamicBulletsPrefabParent => _dynamicBulletsPrefabParent;
        public Transform DynamicVFXPrefabParent => _dynamicVFXPrefabParent;
        public Transform DynamicObstaclesPrefabParent => _dynamicObstaclesPrefabParent;
    }
}
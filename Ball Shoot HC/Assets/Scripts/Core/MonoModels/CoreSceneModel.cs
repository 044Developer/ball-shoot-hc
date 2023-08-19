using UnityEngine;

namespace BallShoot.Core.MonoModels
{
    public class CoreSceneModel : MonoBehaviour
    {
        [SerializeField] private Transform _dynamicPrefabParent;
        [SerializeField] private Transform _dynamicBulletsPrefabParent;
        [SerializeField] private Transform _dynamicVFXPrefabParent;

        public Transform DynamicPrefabParent => _dynamicPrefabParent;
        public Transform DynamicBulletsPrefabParent => _dynamicBulletsPrefabParent;
        public Transform DynamicVFXPrefabParent => _dynamicVFXPrefabParent;
    }
}
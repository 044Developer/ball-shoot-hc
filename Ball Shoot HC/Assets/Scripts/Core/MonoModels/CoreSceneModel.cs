using UnityEngine;

namespace BallShoot.Core.MonoModels
{
    public class CoreSceneModel : MonoBehaviour
    {
        [SerializeField] private Transform _dynamicPrefabParent;

        public Transform DynamicPrefabParent => _dynamicPrefabParent;
    }
}
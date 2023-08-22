using BallShoot.Core.Data.Settings;
using UnityEngine;

namespace BallShoot.Core.MonoModels
{
    public class CoreSettingsModel : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private PrefabSettings _prefabSettings;

        [Header("Spawn Positions")]
        [SerializeField] private CoreSpawnPositions _spawnPositions;

        public PrefabSettings PrefabSettings => _prefabSettings;
        public CoreSpawnPositions SpawnPositions => _spawnPositions;
    }
}
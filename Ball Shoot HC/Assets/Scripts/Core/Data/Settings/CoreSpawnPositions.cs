using System;
using UnityEngine;

namespace BallShoot.Core.Data.Settings
{
    [Serializable]
    public class CoreSpawnPositions
    {
        [Header("Exit Door")]
        [SerializeField] private Transform _exitDoorSpawnPosition;

        public Transform ExitDoorSpawnPosition => _exitDoorSpawnPosition;
    }
}
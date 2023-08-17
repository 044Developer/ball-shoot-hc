using System;
using UnityEngine;

namespace BallShoot.Core.Data.Settings
{
    [Serializable]
    public class CoreSpawnPositions
    {
        [Header("Exit Door")]
        [SerializeField] private Transform _exitDoorSpawnPosition;

        [Header("Player")]
        [SerializeField] private Transform _playerSpawnPosition;
        
        public Transform ExitDoorSpawnPosition => _exitDoorSpawnPosition;
        public Transform PlayerSpawnPosition => _playerSpawnPosition;
    }
}
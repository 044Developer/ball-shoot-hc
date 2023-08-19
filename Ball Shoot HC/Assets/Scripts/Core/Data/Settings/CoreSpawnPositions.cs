using System;
using System.Collections.Generic;
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

        [Header("Bullet")]
        [SerializeField] private Transform _bulletSpawnPosition;

        [Header("Obstacles Area")]
        [SerializeField] private List<Transform> _obstacleAreaPositions;
        
        public Transform ExitDoorSpawnPosition => _exitDoorSpawnPosition;
        public Transform PlayerSpawnPosition => _playerSpawnPosition;
        public Transform BulletSpawnPosition => _bulletSpawnPosition;
        public List<Transform> ObstacleAreaPositions => _obstacleAreaPositions;
    }
}
using System;
using System.Collections.Generic;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.BulletVFX.Facade;
using BallShoot.Core.Features.ExitDoor.View;
using BallShoot.Core.Features.Obstacles.Facade;
using BallShoot.Core.Features.Player.View;
using UnityEngine;

namespace BallShoot.Core.Data.Settings
{
    [Serializable]
    public class PrefabSettings
    {
        [Header("Environment")]
        [SerializeField] private ExitDoorView _exitDoorPrefab;
        
        [Header("Player")]
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private BulletFacade _bulletPrefab;
        
        [Header("VFX")]
        [SerializeField] private DestroyVFXFacade _destroyVFXPrefab;

        [Header("Obstacles")]
        [SerializeField] private List<ObstacleFacade> _obstacleList;

        public ExitDoorView ExitDoorPrefab => _exitDoorPrefab;
        public PlayerView PlayerPrefab => _playerPrefab;
        public BulletFacade BulletPrefab => _bulletPrefab;
        public DestroyVFXFacade DestroyVFXPrefab => _destroyVFXPrefab;
        public List<ObstacleFacade> ObstacleList => _obstacleList;
    }
}
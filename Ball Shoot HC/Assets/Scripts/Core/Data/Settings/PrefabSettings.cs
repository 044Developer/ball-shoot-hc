using System;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.ExitDoor.View;
using BallShoot.Core.Features.Player.View;
using UnityEngine;

namespace BallShoot.Core.Data.Settings
{
    [Serializable]
    public class PrefabSettings
    {
        [SerializeField] private ExitDoorView _exitDoorPrefab;
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private BulletFacade _bulletPrefab;

        public ExitDoorView ExitDoorPrefab => _exitDoorPrefab;
        public PlayerView PlayerPrefab => _playerPrefab;
        public BulletFacade BulletPrefab => _bulletPrefab;
    }
}
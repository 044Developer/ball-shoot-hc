using System;
using BallShoot.Core.Features.Bullet.Facade;
using BallShoot.Core.Features.BulletVFX.Facade;
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
        [SerializeField] private DestroyVFXFacade _destroyVFXPrefab;

        public ExitDoorView ExitDoorPrefab => _exitDoorPrefab;
        public PlayerView PlayerPrefab => _playerPrefab;
        public BulletFacade BulletPrefab => _bulletPrefab;
        public DestroyVFXFacade DestroyVFXPrefab => _destroyVFXPrefab;
    }
}
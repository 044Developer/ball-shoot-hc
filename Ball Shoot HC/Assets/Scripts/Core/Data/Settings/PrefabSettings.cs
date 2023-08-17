using System;
using BallShoot.Core.Features.ExitDoor.View;
using UnityEngine;

namespace BallShoot.Core.Data.Settings
{
    [Serializable]
    public class PrefabSettings
    {
        [SerializeField] private ExitDoorView _exitDoorPrefab;

        public ExitDoorView ExitDoorPrefab => _exitDoorPrefab;
    }
}
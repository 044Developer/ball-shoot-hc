using System;
using BallShoot.Core.Data.Runtime;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.Systems.SizeChange
{
    public interface IBulletChangeSizeSystem
    {
    }
    
    public class BulletChangeSizeSystem : IInitializable, IDisposable
    {
        private readonly CoreRuntimeData _coreRuntimeData;

        public BulletChangeSizeSystem(CoreRuntimeData coreRuntimeData)
        {
            _coreRuntimeData = coreRuntimeData;
        }

        public void Initialize()
        {
            _coreRuntimeData.OnTapStartedEvent += ActivateSizeChange;
            _coreRuntimeData.OnTapEvent += UpdateSize;
            _coreRuntimeData.OnTapFinishedEvent += DeactivateSizeChange;
        }

        public void Dispose()
        {
            _coreRuntimeData.OnTapStartedEvent -= ActivateSizeChange;
            _coreRuntimeData.OnTapEvent -= UpdateSize;
            _coreRuntimeData.OnTapFinishedEvent -= DeactivateSizeChange;
        }

        private void ActivateSizeChange()
        {
            Debug.Log("STARTED BULLET");
        }

        private void UpdateSize()
        {
            Debug.Log("PRESS BULLET");
        }

        private void DeactivateSizeChange()
        {
            Debug.Log("DEATIVATE BULLET");
        }
    }
}
using BallShoot.Core.Data.Runtime;
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.Systems.SizeChange
{
    public interface IBulletChangeSizeSystem
    {
        void Tick();
    }
    
    public class BulletChangeSizeSystem : IBulletChangeSizeSystem
    {
        private readonly CoreRuntimeData _coreRuntimeData;

        public BulletChangeSizeSystem(CoreRuntimeData coreRuntimeData)
        {
            _coreRuntimeData = coreRuntimeData;
        }
        
        public void Tick()
        {
            if (_coreRuntimeData.InputLength > 0)
            {
                Debug.Log($"Pressure = {_coreRuntimeData.InputLength}");
            }
        }
    }
}
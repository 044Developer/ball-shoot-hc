using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Bullet.View
{
    public class BulletView : MonoBehaviour, IBulletView, IPoolable<IMemoryPool>
    {
        
        public class Factory : PlaceholderFactory<BulletView>
        {
        }

        public void OnDespawned()
        {
        }

        public void OnSpawned(IMemoryPool pool)
        {
        }
    }
}
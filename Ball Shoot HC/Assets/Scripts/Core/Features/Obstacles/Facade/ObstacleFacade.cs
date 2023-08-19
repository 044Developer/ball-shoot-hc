using BallShoot.Core.Features.Obstacles.Systems.SetUp;
using BallShoot.Core.Features.Obstacles.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Obstacles.Facade
{
    public class ObstacleFacade : MonoBehaviour, IPoolable<Vector3, IMemoryPool>
    {
        private IMemoryPool _pool;
        private IObstacleSetUpSystem _setUpSystem;
        private ObstacleView _view;

        [Inject]
        public void Construct(IObstacleSetUpSystem setUpSystem, ObstacleView view)
        {
            _setUpSystem = setUpSystem;
            _view = view;
        }
        
        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            _view.Transform.position = position;
            _pool = pool;
        }

        public void OnDespawned()
        {
            _setUpSystem.Reset();
            _pool = null;
        }

        public void Die()
        {
            _pool.Despawn(this);
        }
        
        public class Factory : PlaceholderFactory<Vector3, ObstacleFacade>
        {
        }
    }
}
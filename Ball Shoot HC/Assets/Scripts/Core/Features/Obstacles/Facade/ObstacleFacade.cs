using BallShoot.Core.Features.Obstacles.Data;
using BallShoot.Core.Features.Obstacles.Model;
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
        private IObstacleView _view;
        private ObstacleModel _model;
        
        [Inject]
        public void Construct(
            IObstacleSetUpSystem setUpSystem,
            IObstacleView view,
            ObstacleModel model)
        {
            _setUpSystem = setUpSystem;
            _view = view;
            _model = model;
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

        public void TakeDamage()
        {
            _view.Collider.enabled = false;
            _model.RuntimeData.State = ObstacleState.Destruction;
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
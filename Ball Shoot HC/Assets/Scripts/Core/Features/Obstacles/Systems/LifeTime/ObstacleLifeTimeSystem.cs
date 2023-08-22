using BallShoot.Core.Features.Obstacles.Facade;
using BallShoot.Core.Features.Obstacles.Model;
using UnityEngine;

namespace BallShoot.Core.Features.Obstacles.Systems.LifeTime
{
    public class ObstacleLifeTimeSystem : IObstacleLifeTimeSystem
    {
        private readonly ObstacleModel _model;
        private readonly ObstacleFacade _facade;

        public ObstacleLifeTimeSystem(ObstacleModel model, ObstacleFacade facade)
        {
            _model = model;
            _facade = facade;
        }
        
        public void Tick()
        {
            CountDownLifeTime();

            CheckCurrentLifeTime();
        }

        private void CountDownLifeTime()
        {
            _model.RuntimeData.CurrentDestructionTime += Time.deltaTime;
        }

        private void CheckCurrentLifeTime()
        {
            if (_model.RuntimeData.CurrentDestructionTime < _model.SettingsData.DestructionDuration)
                return;
            
            _facade.Die();
        }
    }
}
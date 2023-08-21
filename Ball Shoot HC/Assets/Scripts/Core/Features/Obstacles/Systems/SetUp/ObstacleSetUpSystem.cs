using BallShoot.Core.Features.Obstacles.Configuration;
using BallShoot.Core.Features.Obstacles.Data;
using BallShoot.Core.Features.Obstacles.Model;
using BallShoot.Core.Features.Obstacles.View;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Obstacles.Systems.SetUp
{
    public class ObstacleSetUpSystem : IInitializable, IObstacleSetUpSystem
    {
        private readonly ObstacleModel _model;
        private readonly ObstacleConfiguration _configuration;
        private readonly IObstacleView _view;

        public ObstacleSetUpSystem(
            ObstacleModel model,
            ObstacleConfiguration configuration,
            IObstacleView view)
        {
            _model = model;
            _configuration = configuration;
            _view = view;
        }
        
        public void Initialize()
        {
            _model.RuntimeData = new ObstacleRuntimeData();
            _model.RuntimeData.State = ObstacleState.InActive;

            _model.SettingsData = new ObstacleSettingsData
            (
                destructionGradient: _configuration.DestructionGradient,
                destructionDuration: _configuration.DestructionDuration
            );
        }

        public void Reset()
        {
            _model.RuntimeData.CurrentDestructionTime = 0f;
            _model.RuntimeData.State = ObstacleState.InActive;
            _view.Collider.gameObject.SetActive(true);


            foreach (GameObject obstacle in _view.ObstaclesObject) 
                obstacle.SetActive(true);
        }
    }
}
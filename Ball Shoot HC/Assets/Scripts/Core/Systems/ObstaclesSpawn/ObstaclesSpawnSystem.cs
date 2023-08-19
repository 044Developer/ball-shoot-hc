using BallShoot.Core.Features.Obstacles.Configuration;
using BallShoot.Core.Features.Obstacles.Facade;
using BallShoot.Core.MonoModels;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Systems.ObstaclesSpawn
{
    public class ObstaclesSpawnSystem : IInitializable, IObstaclesSpawnSystem
    {
        private readonly ObstacleConfiguration _configuration;
        private readonly ObstacleFacade.Factory _pool;
        private readonly CoreSettingsModel _coreSettingsModel;

        private Vector3 _lastPosition;

        public ObstaclesSpawnSystem(
            ObstacleConfiguration configuration,
            ObstacleFacade.Factory pool,
            CoreSettingsModel coreSettingsModel)
        {
            _configuration = configuration;
            _pool = pool;
            _coreSettingsModel = coreSettingsModel;
        }

        public void Initialize()
        {
            RespawnObstacles();
        }

        public void RespawnObstacles()
        {
            for (int i = 0; i < _configuration.ObstacleCount; i++)
            {
                Vector3 randomPosition = GetRandomPosition();

                if (i > 0 && Vector3.Distance(randomPosition, _lastPosition) < _configuration.ObstacleOffset)
                {
                    continue;
                }

                _pool.Create(randomPosition);
                _lastPosition = randomPosition;
            }
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(
                Mathf.Min(
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[0].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[1].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[2].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[3].position.x),
                Mathf.Max(
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[0].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[1].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[2].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[3].position.x));
            
            float y = 0;
            
            float z = Random.Range(Mathf.Min(
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[0].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[1].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[2].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[3].position.z),
                Mathf.Max(
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[0].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[1].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[2].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[3].position.z));

            return new Vector3(x, y, z);
        }
    }
}
using BallShoot.Core.Features.Obstacles.Configuration;
using BallShoot.Core.Features.Obstacles.Facade;
using BallShoot.Core.MonoModels;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Systems.ObstaclesSpawn
{
    public class ObstaclesSpawnSystem : IInitializable, IObstaclesSpawnSystem
    {
        private const int FIRST_POS_INDEX = 0;
        private const int SECOND_POS_INDEX = 1;
        private const int THIRD_POS_INDEX = 2;
        private const int FORTH_POS_INDEX = 3;
        
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
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FIRST_POS_INDEX].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[SECOND_POS_INDEX].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[THIRD_POS_INDEX].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FORTH_POS_INDEX].position.x),
                Mathf.Max(
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FIRST_POS_INDEX].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[SECOND_POS_INDEX].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[THIRD_POS_INDEX].position.x,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FORTH_POS_INDEX].position.x));
            
            float y = _configuration.ObstacleHeight;
            
            float z = Random.Range(Mathf.Min(
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FIRST_POS_INDEX].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[SECOND_POS_INDEX].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[THIRD_POS_INDEX].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FORTH_POS_INDEX].position.z),
                Mathf.Max(
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FIRST_POS_INDEX].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[SECOND_POS_INDEX].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[THIRD_POS_INDEX].position.z,
                    _coreSettingsModel.SpawnPositions.ObstacleAreaPositions[FORTH_POS_INDEX].position.z));

            return new Vector3(x, y, z);
        }
    }
}
using BallShoot.Core.Features.Obstacles.Data;
using BallShoot.Core.Features.Obstacles.Model;
using BallShoot.Core.Features.Obstacles.Systems.Animation;
using BallShoot.Core.Features.Obstacles.Systems.LifeTime;
using Zenject;

namespace BallShoot.Core.Features.Obstacles.Systems.Update
{
    public class ObstacleUpdateSystem : ITickable
    {
        private readonly IObstacleLifeTimeSystem _lifeTimeSystem;
        private readonly IObstacleAnimationSystem _animationSystem;
        private readonly ObstacleModel _model;

        public ObstacleUpdateSystem(
            IObstacleLifeTimeSystem lifeTimeSystem,
            IObstacleAnimationSystem animationSystem,
            ObstacleModel model)
        {
            _lifeTimeSystem = lifeTimeSystem;
            _animationSystem = animationSystem;
            _model = model;
        }
        
        public void Tick()
        {
            if (_model.RuntimeData.State != ObstacleState.Destruction)
                return;
            
            _lifeTimeSystem.Tick();
            
            _animationSystem.Tick();
        }
    }
}
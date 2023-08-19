using BallShoot.Core.Features.Obstacles.Model;
using BallShoot.Core.Features.Obstacles.View;
using UnityEngine;

namespace BallShoot.Core.Features.Obstacles.Systems.Animation
{
    public class ObstacleAnimationSystem : IObstacleAnimationSystem
    {
        private readonly ObstacleModel _model;
        private readonly ObstacleView _view;

        public ObstacleAnimationSystem(ObstacleModel model, ObstacleView view)
        {
            _model = model;
            _view = view;
        }
        
        public void Tick()
        {
            AnimateObstacles();
        }

        private void AnimateObstacles()
        {
            var currentColor =_model.SettingsData.DestructionGradient.Evaluate(_model.RuntimeData.CurrentDestructionTime);

            foreach (MeshRenderer mesh in _view.ObstaclesMesh) 
                mesh.material.color = currentColor;
        }
    }
}
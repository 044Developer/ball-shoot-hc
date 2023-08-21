using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using UnityEngine;

namespace BallShoot.Core.Features.Player.Systems.Destroy
{
    public class PlayerDestroySystem : IPlayerDestroySystem
    {
        private readonly PlayerModel _model;

        public PlayerDestroySystem(PlayerModel model)
        {
            _model = model;
        }
        
        public void Die()
        {
            _model.RuntimeData.Status = PlayerStatus.Died;
            Debug.Log("DIE");
        }
    }
}
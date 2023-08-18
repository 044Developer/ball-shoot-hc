using UnityEngine;

namespace BallShoot.Core.Features.Player.Data
{
    public struct PlayerRuntimeData
    {
        public PlayerStatus Status;
        public Vector3 CurrentPlayerSize;
        public Color CurrentPlayerColor;

        public PlayerRuntimeData(PlayerStatus status, Vector3 currentPlayerSize, Color currentPlayerColor)
        {
            Status = status;
            CurrentPlayerSize = currentPlayerSize;
            CurrentPlayerColor = currentPlayerColor;
        }
    }
}
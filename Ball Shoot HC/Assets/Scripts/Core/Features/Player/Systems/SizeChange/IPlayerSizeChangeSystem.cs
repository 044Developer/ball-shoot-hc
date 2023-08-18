namespace BallShoot.Core.Features.Player.Systems.SizeChange
{
    public interface IPlayerSizeChangeSystem
    {
        void ActivateSizeChange();
        void UpdateSize();
        void DeactivateSizeChange();
    }
}
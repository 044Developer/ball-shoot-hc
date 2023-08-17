namespace BallShoot.Core.Features.ExitDoor.Systems.Animation
{
    public interface IExitDoorAnimationSystem
    {
        public void OpenDoor();
        public void ForceOpenDoor();
        public void CloseDoor();
        public void ForceCloseDoor();
    }
}
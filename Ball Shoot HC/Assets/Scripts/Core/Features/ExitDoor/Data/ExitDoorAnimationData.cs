using DG.Tweening;

namespace BallShoot.Core.Features.ExitDoor.Data
{
    public class ExitDoorAnimationData
    {
        /* Open Animation */
        public float DoorOpenSpeed = 2f;
        public Ease DoorOpenEase = Ease.Linear;
        
        /* Close Animation */
        public float DoorCloseSpeed = 2f;
        public Ease DoorCloseEase = Ease.Linear;
    }
}
namespace BallShoot.Core.Data.Runtime
{
    public class CoreRuntimeData
    {
        public delegate void OnTapStarted();
        public OnTapStarted OnTapStartedEvent;

        public delegate void OnTap();
        public OnTap OnTapEvent;
        public delegate void OnTapFinished();
        public OnTapFinished OnTapFinishedEvent;
    }
}
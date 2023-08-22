using BallShoot.Core.Features.ExitDoor.Model;
using BallShoot.Core.Features.ExitDoor.View;
using DG.Tweening;

namespace BallShoot.Core.Features.ExitDoor.Systems.Animation
{
    public class ExitDoorAnimationSystem : IExitDoorAnimationSystem
    {
        private readonly IExitDoorView _view;
        private readonly ExitDoorModel _model;
        
        public ExitDoorAnimationSystem(IExitDoorView view, ExitDoorModel model)
        {
            _view = view;
            _model = model;
        }
        
        public void OpenDoor()
        {
            PlayOpenAnimation();
        }

        public void ForceOpenDoor()
        {
            _view.LeftDoor.localPosition = _view.OpenedLeftDoorPosition;
            _view.RightDoor.localPosition = _view.OpenedRightDoorPosition;
        }

        public void CloseDoor()
        {
            PlayCloseAnimation();
        }

        public void ForceCloseDoor()
        {
            _view.LeftDoor.localPosition = _view.ClosedLeftDoorPosition;
            _view.RightDoor.localPosition = _view.ClosedRightDoorPosition;
        }

        #region Door Open Animation

        private void PlayOpenAnimation()
        {
            ForceCloseDoor();
                
            var doorOpenSequence = DOTween.Sequence();

            doorOpenSequence
                .SetRecyclable(true)
                .SetEase(_model.AnimationData.DoorOpenEase)
                .Append(_view.LeftDoor
                    .DOLocalMove(_view.OpenedLeftDoorPosition,_model.AnimationData.DoorOpenSpeed))
                .Join(_view.RightDoor
                    .DOLocalMove(_view.OpenedRightDoorPosition,_model.AnimationData.DoorOpenSpeed));

            doorOpenSequence.Play();
        }

        #endregion

        #region Door Close Animation

        private void PlayCloseAnimation()
        {
            ForceOpenDoor();
            var doorCloseSequence = DOTween.Sequence();

            doorCloseSequence
                .SetEase(_model.AnimationData.DoorCloseEase)
                .Append(_view.LeftDoor
                    .DOLocalMove(_view.ClosedLeftDoorPosition, _model.AnimationData.DoorCloseSpeed))
                .Join(_view.RightDoor
                    .DOLocalMove(_view.ClosedRightDoorPosition, _model.AnimationData.DoorCloseSpeed));

            doorCloseSequence.Play();
        }

        #endregion
    }
}
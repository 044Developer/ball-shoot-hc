using BallShoot.Core.Features.ExitDoor.Configs;
using BallShoot.Core.Features.ExitDoor.Model;
using BallShoot.Core.Features.ExitDoor.View;
using BallShoot.Core.MonoModels;
using Zenject;

namespace BallShoot.Core.Features.ExitDoor.Systems.SetUp
{
    public class ExitDoorSetUpSystem : IInitializable
    {
        private readonly IExitDoorView _view;
        private readonly ExitDoorModel _model;
        private readonly CoreSettingsModel _coreSettingsModel;
        private readonly ExitDoorConfiguration _exitDoorConfiguration;

        public ExitDoorSetUpSystem(IExitDoorView view, ExitDoorModel model, CoreSettingsModel coreSettingsModel, ExitDoorConfiguration exitDoorConfiguration)
        {
            _view = view;
            _model = model;
            _coreSettingsModel = coreSettingsModel;
            _exitDoorConfiguration = exitDoorConfiguration;
        }

        public void Initialize()
        {
            PositionExitDoor();
            SetUpAnimationModel();
        }

        private void PositionExitDoor()
        {
            _view.ExitDoorTransform.position = _coreSettingsModel.SpawnPositions.ExitDoorSpawnPosition.position;
        }

        private void SetUpAnimationModel()
        {
            _model.AnimationData.DoorOpenSpeed = _exitDoorConfiguration.DoorOpenSpeed;
            _model.AnimationData.DoorOpenEase = _exitDoorConfiguration.DoorOpenEase;
            _model.AnimationData.DoorCloseSpeed = _exitDoorConfiguration.DoorCloseSpeed;
            _model.AnimationData.DoorCloseEase = _exitDoorConfiguration.DoorCloseEase;
        }
    }
}
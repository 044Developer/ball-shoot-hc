using BallShoot.Core.Features.Road.Configuration;
using BallShoot.Core.Features.Road.Data;
using BallShoot.Core.Features.Road.Model;
using BallShoot.Core.Features.Road.View;
using BallShoot.Core.MonoModels;
using Zenject;

namespace BallShoot.Core.Features.Road.Systems.SetUp
{
    public class RoadSetUpSystem : IInitializable, IRoadSetUpSystem
    {
        private readonly RoadModel _model;
        private readonly RoadConfiguration _configuration;
        private readonly IRoadView _view;
        private readonly CoreSettingsModel _coreSettingsModel;

        public RoadSetUpSystem(RoadModel model, RoadConfiguration configuration, IRoadView view, CoreSettingsModel coreSettingsModel)
        {
            _model = model;
            _configuration = configuration;
            _view = view;
            _coreSettingsModel = coreSettingsModel;
        }
        
        public void Initialize()
        {
            _model.SettingsData = new RoadSettingsData
            (
                regularSize: _configuration.RegularSize,
                minSize: _configuration.MinSize,
                decreaseMultiplier: _configuration.DecreaseMultiplier
                );

            _model.RoadRuntimeData = new RoadRuntimeData()
            {
                State = RoadState.InActive,
                CurrentSize = _model.SettingsData.RegularSize
            };
            
            _view.Transform.position = _coreSettingsModel.SpawnPositions.RoadSpawnPosition.position;
        }

        public void Reset()
        {
            _model.RoadRuntimeData.CurrentSize = _model.SettingsData.RegularSize;
            _model.RoadRuntimeData.State = RoadState.InActive;
        }
    }
}
using System;
using BallShoot.Core.Data.Runtime;
using BallShoot.Core.Data.Types;
using BallShoot.Core.Features.Player.Data;
using BallShoot.Core.Features.Player.Models;
using BallShoot.Core.Features.Road.Data;
using BallShoot.Core.Features.Road.Model;
using BallShoot.Core.Features.Road.View;
using BallShoot.Core.Systems.LevelGamePlay;
using UnityEngine;
using Zenject;

namespace BallShoot.Core.Features.Road.Systems.SizeChange
{
    public class RoadSizeChangeSystem : IInitializable, IDisposable
    {
        private readonly CoreRuntimeData _coreRuntimeData;
        private readonly RoadModel _model;
        private readonly IRoadView _view;
        private readonly ILevelGamePlaySystem _levelGamePlaySystem;

        public RoadSizeChangeSystem(
            CoreRuntimeData coreRuntimeData,
            RoadModel model,
            IRoadView view,
            ILevelGamePlaySystem levelGamePlaySystem)
        {
            _coreRuntimeData = coreRuntimeData;
            _model = model;
            _view = view;
            _levelGamePlaySystem = levelGamePlaySystem;
        }
        
        public void Initialize()
        {
            _coreRuntimeData.OnTapStartedEvent += ActivateSizeChange;
            _coreRuntimeData.OnTapEvent += UpdateSize;
            _coreRuntimeData.OnTapFinishedEvent += DeactivateSizeChange;
        }


        public void Dispose()
        {
            _coreRuntimeData.OnTapStartedEvent -= ActivateSizeChange;
            _coreRuntimeData.OnTapEvent -= UpdateSize;
            _coreRuntimeData.OnTapFinishedEvent -= DeactivateSizeChange;
        }
        
        private void ActivateSizeChange()
        {
            if(_model.RoadRuntimeData.State == RoadState.MinSize)
                return;

            if (_levelGamePlaySystem.CurrentLevelState == LevelStateType.WaitForResult)
                return;

            _model.RoadRuntimeData.State = RoadState.Changing;
        }

        private void UpdateSize()
        {
            if (_model.RoadRuntimeData.State != RoadState.Changing)
                return;

            if (_levelGamePlaySystem.CurrentLevelState == LevelStateType.WaitForResult)
                return;

            _model.RoadRuntimeData.CurrentSize.x -= _model.SettingsData.DecreaseMultiplier * Time.deltaTime;

            if (_model.RoadRuntimeData.CurrentSize.x <= _model.SettingsData.MinSize.x)
            {
                _model.RoadRuntimeData.State = RoadState.MinSize;
            }

            UpdateRoadSize();
        }

        private void DeactivateSizeChange()
        {
            if(_model.RoadRuntimeData.State == RoadState.MinSize)
                return;

            if (_levelGamePlaySystem.CurrentLevelState == LevelStateType.WaitForResult)
                return;
            
            _model.RoadRuntimeData.State = RoadState.InActive;
        }

        private void UpdateRoadSize()
        {
            _view.Transform.localScale = _model.RoadRuntimeData.CurrentSize;
        }
    }
}
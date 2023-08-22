using System;
using UnityEngine;
using UnityEngine.UI;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loose
{
    [Serializable]
    public class LooseScreenViewModel
    {
        [SerializeField] private Button _restartButton;

        public Button RestartButton => _restartButton;
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Win
{
    [Serializable]
    public class WinScreenViewModel
    {
        [SerializeField] private Button _restartButton;

        public Button RestartButton => _restartButton;
    }
}
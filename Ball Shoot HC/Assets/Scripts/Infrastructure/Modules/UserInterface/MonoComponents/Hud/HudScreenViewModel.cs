using System;
using UnityEngine;
using UnityEngine.UI;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Hud
{
    [Serializable]
    public class HudScreenViewModel
    {
        [SerializeField] private Button _launchBallButton;

        public Button LaunchBallButton => _launchBallButton;
    }
}
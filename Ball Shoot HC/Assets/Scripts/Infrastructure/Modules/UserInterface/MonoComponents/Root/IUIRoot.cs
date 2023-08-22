using UnityEngine;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Root
{
    public interface IUIRoot
    {
        public RectTransform HUDParent { get; }
        public RectTransform ScreensParent { get; }
    }
}
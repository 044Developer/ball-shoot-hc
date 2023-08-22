using UnityEngine;

namespace BallShoot
{
    public interface IUIRoot
    {
        public RectTransform HUDParent { get; }
        public RectTransform ScreensParent { get; }
    }
}
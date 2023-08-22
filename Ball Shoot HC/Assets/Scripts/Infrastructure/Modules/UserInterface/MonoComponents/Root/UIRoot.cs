using UnityEngine;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Root
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        [SerializeField] private RectTransform _hudParent;
        [SerializeField] private RectTransform _screensParent;

        public RectTransform HUDParent => _hudParent;
        public RectTransform ScreensParent => _screensParent;
    }
}

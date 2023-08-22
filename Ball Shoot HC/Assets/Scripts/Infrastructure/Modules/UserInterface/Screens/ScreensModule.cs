using System.Collections.Generic;
using BallShoot.Infrastructure.Modules.CustomFactory;
using BallShoot.Infrastructure.Modules.UserInterface.Container;
using BallShoot.Infrastructure.Modules.UserInterface.Data;
using BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Root;
using UnityEngine;

namespace BallShoot.Infrastructure.Modules.UserInterface.Screens
{
    public class ScreensModule : IScreensModule
    {
        private readonly IUIRoot _root;
        private readonly ICustomFactoryModule _customFactory;
        private readonly IUIPathContainer _uiPathContainer;
        private readonly Dictionary<UIType, BaseUIElement> _cachedScreens;

        public ScreensModule(IUIRoot root, ICustomFactoryModule customFactory, IUIPathContainer uiPathContainer)
        {
            _root = root;
            _customFactory = customFactory;
            _uiPathContainer = uiPathContainer;
            _cachedScreens = new Dictionary<UIType, BaseUIElement>();
        }

        public void OpenScreen<T>(UIType type) where T : BaseUIElement
        {
            if (!_cachedScreens.ContainsKey(type))
            {
                string path = _uiPathContainer.GetUIPath(type);
                BaseUIElement element = _customFactory.Create<T>(path, _root.ScreensParent);
                _cachedScreens.Add(type, element);
                element.Initialize();
            }
            
            _cachedScreens[type].Open();
        }

        public void CloseScreen(UIType type, bool removeFromCache)
        {
            if (!_cachedScreens.ContainsKey(type))
                return;
            
            _cachedScreens[type].Close();

            if (removeFromCache)
            {
                _cachedScreens[type].Dispose();
                Object.Destroy(_cachedScreens[type].gameObject);
                _cachedScreens.Remove(type);
            }
        }
    }
}
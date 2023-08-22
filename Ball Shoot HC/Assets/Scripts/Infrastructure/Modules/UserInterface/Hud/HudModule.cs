using System.Collections.Generic;
using BallShoot.Infrastructure.Modules.CustomFactory;
using BallShoot.Infrastructure.Modules.UserInterface.Container;
using BallShoot.Infrastructure.Modules.UserInterface.Data;
using UnityEngine;

namespace BallShoot.Infrastructure.Modules.UserInterface.Hud
{
    public class HudModule : IHudModule
    {
        private readonly IUIRoot _root;
        private readonly Dictionary<UIType, BaseUIElement> _cachedHud;
        private readonly ICustomFactoryModule _customFactory;
        private readonly IUIPathContainer _uiPathContainer;

        public HudModule(IUIRoot root, ICustomFactoryModule customFactory, IUIPathContainer uiPathContainer)
        {
            _root = root;
            _customFactory = customFactory;
            _uiPathContainer = uiPathContainer;
            _cachedHud = new Dictionary<UIType, BaseUIElement>();
        }

        public void OpenHud<T>(UIType type) where T : BaseUIElement
        {
            if (!_cachedHud.ContainsKey(type))
            {
                string path = _uiPathContainer.GetUIPath(type);
                BaseUIElement element = _customFactory.Create<T>(path, _root.HUDParent);
                _cachedHud.Add(type, element);
                element.Initialize();
            }
            
            _cachedHud[type].Open();
        }


        public void CloseHud(UIType type, bool removeFromCache)
        {
            if (!_cachedHud.ContainsKey(type))
                return;
            
            _cachedHud[type].Close();

            if (removeFromCache)
            {
                _cachedHud[type].Dispose();
                Object.Destroy(_cachedHud[type].gameObject);
                _cachedHud.Remove(type);
            }
        }
    }
}
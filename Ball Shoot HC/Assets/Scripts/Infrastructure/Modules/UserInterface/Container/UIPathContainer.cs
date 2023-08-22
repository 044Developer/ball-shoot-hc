using System.Collections.Generic;
using BallShoot.Infrastructure.Modules.UserInterface.Data;
using Zenject;

namespace BallShoot.Infrastructure.Modules.UserInterface.Container
{
    public class UIPathContainer : IUIPathContainer, IInitializable
    {
        private readonly Dictionary<UIType, string> _cachedPanelConfigs = null;

        public UIPathContainer()
        {
            _cachedPanelConfigs = new Dictionary<UIType, string>();
        }

        public void Initialize()
        {
            RegisterConfigs();
        }
        
        public string GetUIPath(UIType type)
        {
            _cachedPanelConfigs.TryGetValue(type, out var config);
            return config;
        }

        private void RegisterConfigs()
        {
            RegisterNewPanelConfig(UIType.Loading, "Prefabs/UI/Screens/Loading_Screen");
            RegisterNewPanelConfig(UIType.Win, "Prefabs/UI/Screens/Win_Screen");
            RegisterNewPanelConfig(UIType.Loose, "Prefabs/UI/Screens/Loose_Screen");
            RegisterNewPanelConfig(UIType.Hud, "Prefabs/UI/HUD/Hud_Screen");
        }

        private void RegisterNewPanelConfig(UIType type, string prefabPath)
        {
            _cachedPanelConfigs.Add(type, prefabPath);
        }
    }
}
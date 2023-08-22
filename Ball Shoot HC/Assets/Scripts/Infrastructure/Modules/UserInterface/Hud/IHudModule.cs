using BallShoot.Infrastructure.Modules.UserInterface.Data;

namespace BallShoot.Infrastructure.Modules.UserInterface.Hud
{
    public interface IHudModule
    {
        void OpenHud<T>(UIType type) where T : BaseUIElement;
        void CloseHud(UIType type, bool removeFromCache);
    }
}
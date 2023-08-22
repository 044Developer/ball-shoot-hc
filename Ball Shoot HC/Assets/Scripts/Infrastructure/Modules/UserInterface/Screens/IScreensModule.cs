using BallShoot.Infrastructure.Modules.UserInterface.Data;

namespace BallShoot.Infrastructure.Modules.UserInterface.Screens
{
    public interface IScreensModule
    {
        void OpenScreen<T>(UIType type) where T : BaseUIElement;
        void CloseScreen(UIType type, bool removeFromCache);
    }
}
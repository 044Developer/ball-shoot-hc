using BallShoot.Infrastructure.Modules.UserInterface.Data;

namespace BallShoot.Infrastructure.Modules.UserInterface.Container
{
    public interface IUIPathContainer
    {
        string GetUIPath(UIType type);
    }
}
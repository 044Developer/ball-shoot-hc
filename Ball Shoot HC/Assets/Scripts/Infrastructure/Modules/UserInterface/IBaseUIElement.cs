namespace BallShoot.Infrastructure.Modules.UserInterface
{
    public interface IBaseUIElement
    {
        void Initialize();
        void Open();
        void Close();
        void Dispose();
    }
}
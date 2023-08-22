using UnityEngine;

namespace BallShoot.Infrastructure.Modules.UserInterface
{
    public abstract class BaseUIElement : MonoBehaviour, IBaseUIElement
    {
        public virtual void Initialize()
        {
        }

        public virtual void Open()
        {
        }

        public virtual void Close()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
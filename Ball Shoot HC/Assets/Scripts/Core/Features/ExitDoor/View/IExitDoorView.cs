using BallShoot.Tools.ObjectCollision;
using UnityEngine;

namespace BallShoot.Core.Features.ExitDoor.View
{
    public interface IExitDoorView
    {
        Transform ExitDoorTransform { get; }
        Transform LeftDoor { get; }
        Transform RightDoor { get; }
        Vector3 OpenedLeftDoorPosition { get; }
        Vector3 ClosedLeftDoorPosition { get; }
        Vector3 OpenedRightDoorPosition { get; }
        Vector3 ClosedRightDoorPosition { get; }        
        CollisionHandler CollisionHandler { get; }
    }
}
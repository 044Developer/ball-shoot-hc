using UnityEngine;

namespace BallShoot.Core.Features.ExitDoor.View
{
    public class ExitDoorView : MonoBehaviour, IExitDoorView
    {
        [Header("Common")]
        [SerializeField] private Transform _exitDoorTransform = null;
        
        [Header("Door")]
        [SerializeField] private Transform _leftDoor;
        [SerializeField] private Transform _rightDoor;

        [Header("Door Settings")]
        [SerializeField] private Vector3 _openedLeftDoorPosition;
        [SerializeField] private Vector3 _closedLeftDoorPosition;
        [SerializeField] private Vector3 _openedRightDoorPosition;
        [SerializeField] private Vector3 _closedRightDoorPosition;

        public Transform ExitDoorTransform => _exitDoorTransform;
        public Transform LeftDoor => _leftDoor;
        public Transform RightDoor => _rightDoor;
        public Vector3 OpenedLeftDoorPosition => _openedLeftDoorPosition;
        public Vector3 ClosedLeftDoorPosition => _closedLeftDoorPosition;
        public Vector3 OpenedRightDoorPosition => _openedRightDoorPosition;
        public Vector3 ClosedRightDoorPosition => _closedRightDoorPosition;
    }
}
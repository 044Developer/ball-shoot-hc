using DG.Tweening;
using UnityEngine;

namespace BallShoot.Core.Features.ExitDoor.Configs
{
    [CreateAssetMenu(menuName = "Configs/Core/ExitDoor", fileName = "exit_door_configuration")]
    public class ExitDoorConfiguration : ScriptableObject
    {
        [Header("Animation")]
        [SerializeField] private float _doorOpenSpeed = 2f;
        [SerializeField] private float _doorCloseSpeed = 2f;
        [SerializeField] private Ease _doorOpenEase = Ease.Linear;
        [SerializeField] private Ease _doorCloseEase = Ease.Linear;

        public float DoorOpenSpeed => _doorOpenSpeed;
        public float DoorCloseSpeed => _doorCloseSpeed;
        public Ease DoorOpenEase => _doorOpenEase;
        public Ease DoorCloseEase => _doorCloseEase;
    }
}
using UnityEngine;

namespace BallShoot.Core.Features.Bullet.View
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Transform _bulletTransform;

        public Transform BulletTransform => _bulletTransform;
    }
}
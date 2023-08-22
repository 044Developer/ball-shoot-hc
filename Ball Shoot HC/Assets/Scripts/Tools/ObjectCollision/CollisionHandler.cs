using System;
using UnityEngine;

namespace BallShoot.Tools.ObjectCollision
{
    public class CollisionHandler : MonoBehaviour
    {
        public event Action<Collision> OnCollisionEnterEvent;
        public event Action<Collision> OnCollisionStayEvent;
        public event Action<Collision> OnCollisionExitEvent;
        public event Action<Collider> OnTriggerEnterEvent;
        public event Action<Collider> OnTriggerStayEvent;
        public event Action<Collider> OnTriggerExitEvent;
        
        private void OnCollisionEnter(Collision other)
        {
            OnCollisionEnterEvent?.Invoke(other);
        }

        private void OnCollisionStay(Collision other)
        {
            OnCollisionStayEvent?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            OnCollisionExitEvent?.Invoke(other);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStayEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitEvent?.Invoke(other);
        }
    }
}
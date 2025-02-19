using System;
using UnityEngine;

namespace Player.Systems.Mono
{
    public class GroundingChecker : MonoBehaviour, IGroundChecker
    {
        public event Action OnGrounded;

        [SerializeField] private float _checkDistance;

        [Space, SerializeField] private Transform _checkerPoint;

        public bool IsOnGround { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (Physics.Raycast(_checkerPoint.position, -transform.up, _checkDistance))
            {
                IsOnGround = true;
                
                OnGrounded?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {

            if (!Physics.Raycast(_checkerPoint.position, -transform.up, _checkDistance))
            {
                IsOnGround = false;
            }
        }
    }
}
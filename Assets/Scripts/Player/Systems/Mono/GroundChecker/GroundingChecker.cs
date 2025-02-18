using System;
using UnityEngine;

namespace Player.Systems.Mono
{
    public class GroundingChecker : MonoBehaviour, IGroundChecker
    {
        public event Action OnGrounded;

        [SerializeField] private float _checkDistance;

        [Space, SerializeField] private Transform _checkerPoint;

        private void OnCollisionEnter(Collision other)
        {
            if (Physics.Raycast(_checkerPoint.position, -transform.up, _checkDistance))
            {
                OnGrounded?.Invoke();
            }
        }
    }
}
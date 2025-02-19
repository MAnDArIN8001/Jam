using System;
using UnityEngine;

namespace Player.Systems.JumpSystem
{
    public abstract class JumpSystem : IDisposable
    {
        protected GameObject _context;
        
        private readonly Rigidbody _rigidbody;

        public JumpSystem(GameObject context)
        {
            if (!context.TryGetComponent<Rigidbody>(out _rigidbody))
            {
                Debug.LogWarning($"Can't resolve required rigidbody component from {context}");
            }

            _context = context;
        }

        public virtual void Jump(float jumpForce, Vector3 direction = default)
        {
            var newVelocity = (direction * jumpForce) + _rigidbody.linearVelocity;

            _rigidbody.linearVelocity = newVelocity;
        }

        public virtual void Dispose() { }
    }
}
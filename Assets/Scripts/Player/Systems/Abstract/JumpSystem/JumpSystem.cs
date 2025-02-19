using System;
using UnityEngine;

namespace Player.Systems.JumpSystem
{
    public abstract class JumpSystem : IDisposable
    {
        protected GameObject _context;

        public JumpSystem(GameObject context)
        {
            _context = context;
        }
        
        public abstract void Jump();

        protected abstract void Jump(Vector3 direction);

        public virtual void Dispose() { }
    }
}
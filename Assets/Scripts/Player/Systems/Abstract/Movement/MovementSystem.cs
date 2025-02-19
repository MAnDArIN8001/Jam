using System;
using UnityEngine;

namespace Player.Systems.Movement
{
    public abstract class MovementSystem : IDisposable
    {
        protected GameObject _context;
        
        public MovementSystem(GameObject context)
        {
            _context = context;
        }
        
        public abstract void Move(Vector3 direction, float speed);

        public virtual void Dispose() { }
    }
}
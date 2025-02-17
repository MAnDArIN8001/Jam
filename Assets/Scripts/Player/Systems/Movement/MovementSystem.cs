using UnityEngine;

namespace Player.Systems.Movement
{
    public abstract class MovementSystem
    {
        public abstract void Move(Vector3 direction, float speed);
    }
}
using UnityEngine;

namespace Player.Systems.Mono
{
    public class GroundingChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField] private float _checkDistance;

        [Space, SerializeField] private Transform _checkerPoint;

        public bool IsOnGround => CheckForGround();

        private bool CheckForGround() => Physics.Raycast(_checkerPoint.position, -transform.up, _checkDistance);
    }
}
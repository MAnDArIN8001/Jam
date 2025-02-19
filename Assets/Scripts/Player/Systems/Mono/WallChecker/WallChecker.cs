using System;
using UnityEngine;

namespace Player.Systems.Mono
{
    public class WallChecker : MonoBehaviour, IWallChecker
    {
        public bool IsOnWall => _isOnWall;

        public Vector3 WallNormal => _wallNormal;
        public Player Player;
        private Vector3 _wallNormal;
        private bool _isOnWall;

        [SerializeField] private float checkDistance = 1.0f; // Дистанция проверки

        private void Update()
        {
            CheckForWalls();
        }

        private void CheckForWalls()
        {
            // Проверяем наличие стены слева
            CheckWall(-Player.transform.right);

            // Проверяем наличие стены справа
            CheckWall(Player.transform.right);
        }

        private void CheckWall(Vector3 direction)
        {
            // Выполняем Raycast
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, checkDistance))
            {
                _isOnWall = true;
                _wallNormal = hit.normal;
                Debug.DrawLine(transform.position, hit.point, Color.red);
                return;
                // Вызываем событие, если игрок коснулся стены
            }
            Debug.DrawLine(transform.position, transform.position + direction.normalized * checkDistance, Color.green);


            _isOnWall = false;
        }
    }
}

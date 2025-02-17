using UnityEngine;

namespace Setup.Player
{
    [CreateAssetMenu(fileName = "NewPlayerSetup", menuName = "Gameplay/Player Setup", order = 0)]
    public class PlayerSetup : ScriptableObject
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float RunningSpeed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
    }
}
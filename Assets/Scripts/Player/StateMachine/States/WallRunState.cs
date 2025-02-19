
using Player.Systems.Mono;
using Player.Systems.Movement;

namespace Player.StateMachine.States
{
    public class WallRunState: State
    {
        private MovementSystem _movementSystem;
        private WallChecker _wallChecker;

        public WallRunState(Player player) : base(player)
        {
            StateType = BehaviourStates.WallRun;
            _movementSystem = player.MovementSystem;
            _wallChecker = player.WallChecker;
        }

        public override void Enter()
        {

        }

        public override void Update()
        {

        }

        public override void Exit()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using Player.StateMachine.States;

namespace Player.StateMachine
{
    public class StateMachine : IDisposable
    {
        private State _currentState;

        private Dictionary<BehaviourStates, State> _states;

        public StateMachine(Player player)
        {
            _states = new Dictionary<BehaviourStates, State>()
            {
                {BehaviourStates.Idle, new IdleState(player)},
                {BehaviourStates.Walk, new WalkState(player)},
                {BehaviourStates.Run, new RunState(player)},
                {BehaviourStates.Jump, new JumpState(player)},
            };
        }

        public void SetState(State newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void Dispose()
        {
            _states.Clear();
        }
    }

    public enum BehaviourStates
    {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Jump = 3,
    }
}
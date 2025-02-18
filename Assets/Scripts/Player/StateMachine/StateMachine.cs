using System;
using System.Collections.Generic;
using Player.StateMachine.States;
using UnityEngine;

namespace Player.StateMachine
{
    public class StateMachine : IDisposable
    {
        private Player _player;
        
        private State _currentState;

        private readonly Dictionary<BehaviourStates, State> _states;

        public StateMachine(Player player)
        {
            _states = new Dictionary<BehaviourStates, State>()
            {
                {BehaviourStates.Idle, new IdleState(player)},
                {BehaviourStates.Walk, new WalkState(player)},
                {BehaviourStates.Run, new RunState(player)},
                {BehaviourStates.Jump, new JumpState(player)},
                {BehaviourStates.Fall, new FallState(player)}
            };
            
            SetState(BehaviourStates.Idle);
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void SetState(BehaviourStates newState)
        {
            _currentState?.Exit();

            if (_states.TryGetValue(newState, out _currentState))
            {
                _currentState.Enter();
            }
            else
            {
                Debug.LogWarning($"Wrong state type {newState.ToString()}");
            }
        }

        public void AddState(BehaviourStates stateType, State state)
        {
            if (_states.ContainsKey(stateType))
            {
                Debug.LogWarning("State machine already contains this state");

                return;
            }
            
            _states.Add(stateType, state);
        }

        public void RemoveState(BehaviourStates stateType)
        {
            if (!_states.ContainsKey(stateType))
            {
                Debug.LogWarning("State machine doesnt contains this state");

                return;
            }

            _states.Remove(stateType);
        }

        public void Dispose()
        {
            _currentState.Exit();
            
            foreach (var item in _states.Values)
            {
                item.Dispose();
            }
            
            _states.Clear();
        }
    }

    public enum BehaviourStates
    {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Jump = 3,
        Fall = 4,
    }
}
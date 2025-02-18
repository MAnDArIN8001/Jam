using System;
using System.Collections.Generic;
using Player.StateMachine.StateTransitions;
using UnityEngine;
using State = Player.StateMachine.States.State;

namespace Player.StateMachine
{
    public class StateMachine : IDisposable
    {
        private State _currentState;

        private readonly Dictionary<BehaviourStates, State> _states;

        private readonly List<Transition> _transitions;

        public StateMachine(Dictionary<BehaviourStates, State> states, List<Transition> transitions = null)
        {
            _states = states;
            _transitions = transitions ?? new List<Transition>();
            
            SetState(BehaviourStates.Idle);
        }

        public void Update()
        {
            for (var i = 0; i < _transitions.Count; i++)
            {
                var transition = _transitions[i];

                if (transition.FromState == _currentState.StateType && transition.Condition())
                {
                    SetState(transition.ToState);
                    
                    break;
                }
            }
            
            _currentState?.Update();
        }

        public void SetState(BehaviourStates newState)
        {
            _currentState?.Exit();

            if (_states.TryGetValue(newState, out _currentState))
            {
                Debug.Log($"Swap on {newState.ToString()}");
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

        public void AddTransitionRule(Transition newTransitionRule)
        {
            if (_transitions.Contains(newTransitionRule))
            {
                Debug.LogWarning($"The system already contains transition rule {newTransitionRule}");

                return;
            }
            
            _transitions.Add(newTransitionRule);
        }

        public void RemoveTransitionRule(Transition transitionRule)
        {
            if (!_transitions.Contains(transitionRule))
            {
                Debug.LogWarning($"The system doesnt contains transition rule {transitionRule}");

                return;
            }

            _transitions.Remove(transitionRule);
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
            _transitions.Clear();
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
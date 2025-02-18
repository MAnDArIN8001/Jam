using System;

namespace Player.StateMachine.StateTransitions
{
    public class Transition
    {
        public BehaviourStates FromState { get; }
        public BehaviourStates ToState { get; }

        public Func<bool> Condition { get; }

        public Transition(BehaviourStates fromState, BehaviourStates toState, Func<bool> condition)
        {
            FromState = fromState;
            ToState = toState;
            Condition = condition;
        } 
    }
}
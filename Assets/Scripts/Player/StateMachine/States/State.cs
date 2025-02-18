using System;

namespace Player.StateMachine.States
{
    public abstract class State : IDisposable
    {
        public BehaviourStates StateType { get; protected set; }
        
        protected Player _player;
        
        public State(Player player)
        {
            _player = player;
        }
        
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();

        public virtual void Dispose() { }
    }
}
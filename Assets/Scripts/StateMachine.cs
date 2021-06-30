using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public class State
    {
        public State(System.Action Enter = null, System.Action Update = null, System.Action Exit = null)
        {
            this.Enter = Enter;
            this.Update = Update;
            this.Exit = Exit;
        }

        public System.Action Enter;
        public System.Action Update;
        public System.Action Exit;
    }

    private State currentState;

    public State CurrentState
    {
        get { return currentState; }
    }

    public StateMachine(State startState, bool runEnterOnInit = true)
    {
        currentState = startState;
        if (runEnterOnInit && null != currentState.Enter)
        {
            currentState.Enter();
        }
    }

    public void ChangeState(State newState)
    {
        if (null != currentState.Exit)
        {
            currentState.Exit();
        }
        currentState = newState;

        if (null != currentState.Enter)
            currentState.Enter();
    }

    public void Update()
    {
        if (null != currentState.Update)
            currentState.Update();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    private State currentState;

    public void Awake()
    {
        if (currentState == null)
        {
            Debug.Log("상태가 없습니다.");
            currentState = GetComponent<Move>();
        }
    }

    public void ChangeState(Func<State> some = null)
    {
        if (some != null)
        {
            currentState = some();
        }
        else
        {
            currentState = GetComponent<Move>();
        }
        ToTheCurrentState();
    }

    private void ToTheCurrentState()
    {
        currentState.Enter();
    }
}
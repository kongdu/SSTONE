using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class StateMachine : MonoBehaviour
    {
        public State currentState;

        public void Awake()
        {
            if (currentState == null)
            {
                Debug.Log("상태가 없습니다.");
                currentState = GetComponent<Move>();
                Debug.Log("상태" + currentState);
            }
        }

        public void ChangeState(Func<State> some = null)
        {
            if (some != null)
            {
                currentState.Exit();
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
}
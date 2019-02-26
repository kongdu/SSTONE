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
                currentState = GetComponent<Move>();
            }
        }

        public void ChangeState(Func<State> some = null)
        {
            if (some != null)
            {
                currentState.enabled = false;
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
            currentState.enabled = true;
        }
    }
}
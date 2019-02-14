using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class StateMachine : MonoBehaviour
    {
        public Dictionary<string, State> stateDictionary = new Dictionary<string, State>();
        private State currentState = null;

        private void Awake()
        {
            stateDictionary.Add("Move", new State_Move());
            stateDictionary.Add("Attack", new State_Attack());
            stateDictionary.Add("Dead", new State_Dead());
            stateDictionary.Add("Damaged", new State_Damaged());
            stateDictionary.Add("PathSet", new State_PathSet());

            if (currentState == null)
            {
                if (stateDictionary.TryGetValue("PathSet", out currentState)) { };
            }
            FindNextKeyValue();
        }

        //스테이트 바꾸면서 스테이트 실행
        public void ChangeState(string nextKeyValue)
        {
            if (stateDictionary.TryGetValue(nextKeyValue, out currentState)) { };
            currentState.Enter();
        }

        //추가될 기능을 위해 따로 빼놓은 함수
        public void RunState(State currentState)
        {
            currentState.Run();
        }

        //넘어갈 상태 키값을 뽑아내는 기능
        public void FindNextKeyValue()
        {
            string nextKeyValue = currentState.ChangeState();
            ChangeState(nextKeyValue);
        }
    }
}
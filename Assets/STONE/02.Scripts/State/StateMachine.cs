using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public enum StateIndex
    { Move, Attack, Dead, Damaged, PathSet, ETC, ETC2 };

    public class StateMachine
    {
        private StateIndex stateIndex = StateIndex.PathSet;
        private State currentState = null;

        private Dictionary<StateIndex, State> stateDataBase;

        /// <summary>
        /// 상태들을 머신에 등록하는 함수
        /// </summary>
        /// <param name="owner">생정자호출한놈의 레퍼런스값을 전달</param>
        public void Initialize(GameObject owner)
        {
            stateDataBase = StateGenerator.Instance.PopStateList(owner);
            if (currentState == null)
            {
                if (stateDataBase.TryGetValue(stateIndex, out currentState)) { Debug.Log("상태를 찾았다.1"); };
            }
        }

        public void StateEnter()
        {
            Debug.Log(currentState);
            currentState.Enter();
        }

        public void NextState(StateIndex changingState)
        {
            stateIndex = changingState;
            if (stateDataBase.TryGetValue(stateIndex, out currentState)) { Debug.Log("상태를 찾았다.2"); };

            StateEnter();
        }
    }
}
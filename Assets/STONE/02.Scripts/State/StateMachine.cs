using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public enum StateIndex
    { Move = 0, Attack, Dead, Damaged, PathSet };

    public class StateMachine
    {
        private StateIndex stateIndex = StateIndex.PathSet;
        private State currentState = null;
        private Dictionary<StateIndex, State> stateDataBase;

        /// <summary>
        /// 상태들을 머신에 등록하는 함수
        /// </summary>
        /// <param name="owner">생정자 호출한 놈의 레퍼런스 값을 전달</param>
        public void Initialize(GameObject owner)
        {
            stateDataBase = StateGenerator.BuildMosterStateList(owner);

            if (currentState == null)
            {
                if (!stateDataBase.TryGetValue(stateIndex, out currentState))
                    throw new Exception($"몬스터 상태 디비에서 {stateIndex}에 해당하는 값을 찾을 수 없음!!");
            }
        }

        /// <summary>
        /// 다음 스테이트로 이동시킨다
        /// </summary>
        /// <param name="changingState">이동시킬 키 값</param>
        public void NextState(StateIndex changingState)
        {
            stateIndex = changingState;
            if (stateDataBase.TryGetValue(stateIndex, out State newState))
            {
                currentState.Exit();
                newState.Enter();
                currentState = newState;
            }
            else
            {
                throw new Exception($"몬스터 상태 디비에서 {stateIndex}에 해당하는 값을 찾을 수 없음!!");
            }
        }
    }
}
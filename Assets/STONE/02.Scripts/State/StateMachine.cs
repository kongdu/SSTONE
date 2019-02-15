using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class StateMachine<T, M> where T : Monster
                                                where M : GameManager
    {
        public Dictionary<string, State<Monster, GameManager>> stateDictionary = new Dictionary<string, State<Monster, GameManager>>();
        private State<Monster, GameManager> currentState = null;

        // 상태들을 딕셔너리에 등록하하고 첫번째 상태를 경로셋팅으로 만드는 과정

        public void Initialize(Monster owner)
        {
            stateDictionary.Add("Move", new State_Move<Monster, GameManager>(owner));
            stateDictionary.Add("Attack", new State_Attack<Monster, GameManager>(owner));
            stateDictionary.Add("Dead", new State_Dead<Monster, GameManager>(owner));
            stateDictionary.Add("Damaged", new State_Damaged<Monster, GameManager>(owner));
            stateDictionary.Add("PathSet", new State_PathSet<Monster, GameManager>(owner));

            if (currentState == null)
            {
                if (stateDictionary.TryGetValue("PathSet", out currentState)) { };
            }
            currentState.Enter();
        }

        // 상태 바꾸기

        public void NextState(Func<string> a)
        {
            string keyValue = a();
            if (stateDictionary.TryGetValue(keyValue, out currentState)) { };
            currentState.Enter();
        }
    }
}
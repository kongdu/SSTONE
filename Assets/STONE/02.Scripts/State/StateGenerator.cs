using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class StateGenerator : Singleton<StateGenerator>
    {
        /// <summary>
        /// 몬스터스테이트리스트를 만들어서 리턴해주는 함수
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public Dictionary<StateIndex, State> PopStateList(GameObject owner)
        {
            Dictionary<StateIndex, State> stateDictionary = new Dictionary<StateIndex, State>();
            stateDictionary.Add(StateIndex.Move, new State_Move(owner));
            stateDictionary.Add(StateIndex.Attack, new State_Attack(owner));
            stateDictionary.Add(StateIndex.Dead, new State_Dead(owner));
            stateDictionary.Add(StateIndex.Damaged, new State_Damaged(owner));
            stateDictionary.Add(StateIndex.PathSet, new State_PathSet(owner));
            //stateDictionary.Add(StateIndex.ETC, new State());
            return stateDictionary;
        }
    }
}
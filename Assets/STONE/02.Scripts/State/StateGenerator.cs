using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class StateGenerator
    {
        /// <summary>
        /// 몬스터스테이트리스트를 만들어서 리턴해주는 함수
        /// </summary>
        /// <param name="owner"></param>
        /// <returns>만들어진 몬스터의 상태 리스트 (Dic)</returns>
        public static Dictionary<StateIndex, State> BuildMosterStateList(GameObject owner) =>
            new Dictionary<StateIndex, State>()
            {
                { StateIndex.Move, new State_Move(owner) },
                { StateIndex.Attack, new State_Attack(owner) },
                { StateIndex.Dead, new State_Dead(owner) },
                { StateIndex.Damaged, new State_Damaged(owner) },
                { StateIndex.PathSet, new State_PathSet(owner) },
            };
    }
}
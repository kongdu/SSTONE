using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Dead : State
    {
        public State_Dead(GameObject owner) : base(owner)
        {
            Initialize(owner);
        }

        public override void Initialize(GameObject owner)
        {
            base.Initialize(owner);
            stateMachine = owner.gameObject.GetComponent<Monster>().stateMachine;
        }

        public override void Enter()
        {
            Debug.Log("죽음");
            Debug.Log("경로설정으로");
            ObjPoolManager.instance.monsterPool.Push(owner.gameObject);
            Debug.Log("풀안에 들어갔음");

            stateMachine.NextState(GetNextState());
        }

        public override void Run()
        {
        }

        public override StateIndex GetNextState()
        {
            return StateIndex.PathSet;
        }

        public override void Exit()
        {
            Debug.Log("죽음상태끝");
        }
    }
}
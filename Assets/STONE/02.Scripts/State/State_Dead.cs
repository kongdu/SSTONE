using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Dead : State
    {
        public State_Dead(GameObject owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("죽음");
            Debug.Log("경로설정으로");
            ObjPoolManager.instance.monsterPool.Push(owner.gameObject);
            //stateMachine.NextState(GetNextState);
        }

        public override void Run()
        {
            Run();
        }

        public override StateIndex GetNextState()
        {
            return StateIndex.PathSet;
        }

        public override void Exit()
        {
            Exit();
        }
    }
}
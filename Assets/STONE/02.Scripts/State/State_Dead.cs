using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Dead<T, M> : State<T, M> where T : Monster
                             where M : GameManager
    {
        public State_Dead(T owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("죽음");
            Debug.Log("공격으로");
            stateMachine.NextState(NextStatekey);
        }

        public override void Run()
        {
            Run();
        }

        public override string NextStatekey()
        {
            return "PathSet";
        }

        public override void Exit()
        {
            Exit();
        }
    }
}
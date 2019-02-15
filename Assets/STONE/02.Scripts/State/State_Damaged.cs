using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Damaged<T, M> : State<T, M> where T : Monster
                             where M : GameManager
    {
        public State_Damaged(T owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("공격당함");
            stateMachine.NextState(NextStatekey);
        }

        public override void Run()
        {
            base.Run();
        }

        public override string NextStatekey()
        {
            return "Dead";
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
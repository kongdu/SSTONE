using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Attack<T, M> : State<T, M>
                    where T : Monster where M : GameManager
    {
        public State_Attack(T owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("어택엔터");
            stateMachine.NextState(NextStatekey);
        }

        public override void Run()
        {
            base.Run();
        }

        public override string NextStatekey()
        {
            return "Damaged";
        }

        public override void Exit()
        {
            Exit();
        }
    }
}
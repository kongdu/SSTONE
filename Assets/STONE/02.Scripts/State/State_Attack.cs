using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Attack : State_Move
    {
        public State_Attack()
        {
            base.Initialize();
        }

        public override void Enter()
        {
            Debug.Log("어택엔터");
        }

        public override void Run()
        {
            base.Run();
        }

        public override string ChangeState()
        {
            return ChangeState();
        }

        public override void Exit()
        {
            Exit();
        }
    }
}
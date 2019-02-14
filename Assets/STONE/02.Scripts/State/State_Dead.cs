using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Dead : State
    {
        public State_Dead()
        {
            base.Initialize();
        }

        public override void Enter()
        {
            Debug.Log("죽음");
            Enter();
        }

        public override void Run()
        {
            Run();
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
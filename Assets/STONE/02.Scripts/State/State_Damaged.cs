using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Damaged : State
    {
        public State_Damaged(GameObject owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("공격당함");
            stateMachine.NextState(StateIndex.Dead);
        }

        public override void Run()
        {
            base.Run();
        }

        public override StateIndex GetNextState()
        {
            return StateIndex.Dead;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
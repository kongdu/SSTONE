using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Attack : State
    {
        public State_Attack(GameObject owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("어택엔터");
            stateMachine.NextState(StateIndex.Damaged);
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
            Exit();
        }
    }
}
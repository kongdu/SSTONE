using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Attack : State
    {
        public State_Attack(GameObject owner) : base(owner)
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
            Debug.Log("어택엔터");
            stateMachine.NextState(GetNextState());
        }

        public override void Run()
        {
            base.Run();
        }

        public override StateIndex GetNextState()
        {
            return StateIndex.Damaged;
        }

        public override void Exit()
        {
        }
    }
}
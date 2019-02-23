using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Damaged : State
    {
        public State_Damaged(GameObject owner) : base(owner)
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
            Debug.Log("공격당함");
            Run();
        }

        public override void Run()
        {
            Debug.Log("파티클출력");
            stateMachine.NextState(GetNextState());
            Exit();
        }

        public override StateIndex GetNextState()
        {
            return StateIndex.Dead;
        }

        public override void Exit()
        {
            Debug.Log("데미지받음상태끝");
        }
    }
}
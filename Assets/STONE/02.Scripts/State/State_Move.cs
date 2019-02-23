using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State_Move : State
    {
        private Mover mover;

        public State_Move(GameObject owner) : base(owner)
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
            Debug.Log("무브");
            if (!owner.activeSelf) { return; }
            mover.On();
            //mover.gameObject.SetActive(true);
        }

        public override void Run()
        {
            base.Run();
        }

        /// <summary>
        /// 스테이트를 찾아내는 함수
        /// </summary>
        /// <returns></returns>
        public override StateIndex GetNextState()
        {
            mover.Off();
            return StateIndex.Attack;
        }

        public void ToAttack()
        {
            mover.Off();
            stateMachine.NextState(StateIndex.Attack);
        }

        public override void Exit()
        {
            //mover.gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Move : State
    {
        private Mover mover;

        public State_Move(GameObject owner)
        {
            Initialize(owner);
        }

        public override void Initialize(GameObject owner)
        {
            base.Initialize(owner);
            mover = owner.gameObject.GetComponent<Mover>();
            mover.completeMoveOperation += GetNextState;
        }

        public override void Enter()
        {
            Debug.Log("무브");
            mover.gameObject.SetActive(true);
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
            Exit();
            return StateIndex.Attack;
        }

        public override void Exit()
        {
            mover.gameObject.SetActive(false);
        }
    }
}
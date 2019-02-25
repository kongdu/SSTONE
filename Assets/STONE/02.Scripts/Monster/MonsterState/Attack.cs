using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Attack : State
    {
        private Attacker attackMove;

        private void Awake()
        {
            attackMove = GetComponent<Attacker>();
            attackMove.AttackEnd += SomethingHappen;
        }

        public override void SomethingHappen()
        {
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Dead>());
        }

        public override void Enter()
        {
            Debug.Log("어택상태로왓다");
            attackMove.enabled = true;
        }

        public override void Exit()
        {
            attackMove.enabled = false;
        }
    }
}
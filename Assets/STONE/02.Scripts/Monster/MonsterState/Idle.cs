using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Idle : State
    {
        private void Awake()
        {
            enabled = false;
        }

        public override void Enter()
        {
        }

        private void OnEnable()
        {
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Move>());
        }

        public override void SomethingHappen()
        {
        }

        public override void Exit()
        {
        }
    }
}
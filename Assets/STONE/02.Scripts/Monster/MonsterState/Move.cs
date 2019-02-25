using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Move : State
    {
        private MonsterMove mm;

        private void Awake()
        {
            mm = GetComponent<MonsterMove>();
        }

        public override void Enter()
        {
            mm.NavOnOff(false);
        }

        public override void SomethingHappen()
        {
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Attack>());
        }

        public override void Exit()
        {
            mm.NavOnOff(true);
            mm.enabled = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State_PathSet : State_Mob_Base
    {
        public State_PathSet(GameObject owner) : base(owner)
        {
            Initialize(owner);
        }

        public override void Initialize(GameObject owner)
        {
            base.Initialize(owner);
        }

        public override void Enter()
        {
            SetPath();
            monster.stateMachine.NextState(StateIndex.Move);
        }

        public override StateIndex GetNextState()
        {
            return StateIndex.Move;
        }

        public override void Exit()
        {
        }

        private void SetPath()
        {
        }
    }
}
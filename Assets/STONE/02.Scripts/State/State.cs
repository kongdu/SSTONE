using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State

    {
        protected StateMachine stateMachine;
        protected GameObject owner;

        public virtual void Initialize(GameObject owner)
        {
            this.owner = owner;
        }

        public virtual void Enter()
        {
        }

        public virtual void Run()
        {
        }

        public virtual StateIndex GetNextState()
        {
            return StateIndex.PathSet;
        }

        public virtual void Exit()
        {
        }
    }
}
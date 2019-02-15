using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State<T, M> where T : Monster
                             where M : GameManager
    {
        protected StateMachine<Monster, GameManager> stateMachine;
        protected Monster owner;
        protected Monster.Info info;

        public virtual void Initialize(Monster tt)
        {
            owner = tt;
            info = owner.info;
            stateMachine = owner.stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void Run()
        {
        }

        public virtual string NextStatekey()
        {
            return null;
        }

        public virtual void Exit()
        {
        }
    }
}
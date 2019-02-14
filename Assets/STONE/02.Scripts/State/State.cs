using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State : MonoBehaviour
    {
        protected StateMachine stateMachine;
        protected Monster monster;
        protected MonsterDataBase monsterDataBase;

        public virtual void Initialize()
        {
            stateMachine = gameObject.GetComponent<StateMachine>();
            monster = gameObject.GetComponent<Monster>();
            monsterDataBase = gameObject.GetComponent<MonsterDataBase>();
        }

        public virtual void Enter()
        {
            stateMachine = gameObject.GetComponent<StateMachine>();
        }

        public virtual void Run()
        {
        }

        public virtual string ChangeState()
        {
            return null;
        }

        public virtual void Exit()
        {
        }
    }
}
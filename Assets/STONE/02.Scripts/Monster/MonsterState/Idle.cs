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
            enabled = false;
            Debug.Log("아이들상태로진입");
        }

        private void OnEnable()
        {
            Debug.Log("꺼졋다");
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Move>());
            Debug.Log("무브상태로 진입할거야");
        }

        public override void SomethingHappen()
        {
        }

        public override void Exit()
        {
        }
    }
}
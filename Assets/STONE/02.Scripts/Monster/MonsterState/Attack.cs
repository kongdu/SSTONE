using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Attack : State
    {
        private Attacker attackMove;
        public Player pl;

        private void Awake()
        {
            attackMove = GetComponent<Attacker>();
            pl = FindObjectOfType<Player>();
            attackMove.AttackEnd += SomethingHappen;
            enabled = false;
        }

        public override void SomethingHappen()
        {
            pl.Hittable();
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Dead>());
        }

        private void OnEnable()
        {
            Debug.Log("어택상태로왓다");
            attackMove.enabled = true;
        }

        //public override void Enter()
        //{
        //    Debug.Log("어택상태로왓다");
        //    attackMove.enabled = true;
        //}
        private void OnDisable()
        {
            attackMove.enabled = false;
        }

        //public override void Exit()
        //{
        //    attackMove.enabled = false;
        //}
    }
}
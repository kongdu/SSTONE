using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Attack : State
    {
        private Attacker attackMove;
        private Hittable playerHittable;
        public Player pl;

        private void Awake()
        {
            attackMove = GetComponent<Attacker>();
            pl = FindObjectOfType<Player>();
            playerHittable = pl.GetComponent<Hittable>();
            attackMove.AttackEnd += SomethingHappen;
            enabled = false;
        }

        public override void SomethingHappen()
        {
            playerHittable.OnHit();
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Dead>());
        }

        private void OnEnable()
        {
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
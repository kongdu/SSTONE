using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Move : State
    {
        private MonsterMove mm;
        private Renderer Rder;

        private void Awake()
        {
            mm = GetComponent<MonsterMove>();
            Rder = GetComponent<Renderer>();
            enabled = false;
        }

        private void OnEnable()
        {
            Rder.enabled = true;
            mm.enabled = true;
            mm.navMeshAgent.enabled = true;
            mm.NavOnOff(false);
            mm.navMeshAgent.SetDestination(Player.Instance.transform.position);
        }

        //public override void Enter()
        //{
        //    mm.navMeshAgent.enabled = true;
        //    mm.NavOnOff(false);
        //}

        public override void SomethingHappen()
        {
            GetComponent<StateMachine>().ChangeState(() => GetComponent<Attack>());
        }

        //public override void Exit()
        //{
        //    mm.NavOnOff(true);
        //    mm.navMeshAgent.enabled = false;
        //    mm.enabled = false;
        //}
        private void OnDisable()
        {
            mm.NavOnOff(true);
            mm.navMeshAgent.enabled = false;
            mm.enabled = false;
        }
    }
}
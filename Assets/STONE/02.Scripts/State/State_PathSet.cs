using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State_PathSet<T, M> : State<T, M> where T : Monster
                                                where M : GameManager
    {
        private IEnumerator<Transform> path;
        private int gateWayNum;

        public State_PathSet(Monster owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("경로설정");

            Debug.Log("1");
            gateWayNum = info.gateWay;
            Debug.Log("게이트웨이번호" + info.gateWay);
            if (info.path != null)
            {
                info.path = null;
            }
            Debug.Log("패스초기화");
            path = SpwanPoints.instance.spwanPoints[gateWayNum].pathDataBase.pathlist[0];
            info.path = this.path;
            Debug.Log("패스셋");
            stateMachine.NextState(NextStatekey);
        }

        public override string NextStatekey()
        {
            return "Move";
        }

        public override void Exit()
        {
        }
    }
}
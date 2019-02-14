using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State_PathSet : State
    {
        private IEnumerator<Transform> path;
        private int gateWayNum;

        public State_PathSet()
        {
            base.Initialize();
        }

        public override void Enter()
        {
            Debug.Log("1");
            gateWayNum = monsterDataBase.gateWay;
            Debug.Log("2");

            path = SpwanPoints.instance.spwanPoints[gateWayNum].pathDataBase.pathlist[0];
            Debug.Log("3");
        }

        public override string ChangeState()
        {
            return "Move";
        }

        public override void Exit()
        {
        }
    }
}
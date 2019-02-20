using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class State_PathSet : State
    {
        private Monster monster;

        public State_PathSet(GameObject owner)
        {
            Initialize(owner);
        }

        public override void Initialize(GameObject owner)
        {
            base.Initialize(owner);
            monster = owner.gameObject.GetComponent<Monster>();
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
            Debug.Log("경로설정실행");
            if (monster.path != null)
            {
                PathDataBase.Instance.completedPathlist.Enqueue(monster.path);
                Debug.Log("경로를 큐안에 넣음");
                monster.path = null;
            }
            Debug.Log("경로초기화성공");
            monster.path = PathDataBase.Instance.completedPathlist.Dequeue();
            Debug.Log(PathDataBase.Instance.completedPathlist.Count);
            Debug.Log("패스셋성공");
        }
    }
}
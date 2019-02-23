using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

namespace TMI
{
    [DefaultExecutionOrder(-300)]
    public class Mover : MonoBehaviour
    {
        private Monster monster;

        public List<Vector3> path;
        public Vector3 target;
        public float speed = 30f;

        public event Action CompleteMoveOperation = () => { };

        public event Action WhenLastPath = () => { };

        private void Awake()
        {
            monster = GetComponent<Monster>();
            path = Path.Build(Vector3.zero);
        }

        public void On()
        {
            //StartCoroutine(MoveToTarget());
        }

        public void Off()
        {
            //StopCoroutine(MoveToTarget());
        }

        // 타깃의 종류에 따라서 다시 이동할지 공격을 할지 결정
        private void SerchingNextProcess()
        {
        }

        private void SetFinalTarget()
        {
        }
    }
}
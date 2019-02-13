using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Monster : MonoBehaviour
    {
        private Rigidbody rb;
        public PathGenerator cp;//test

        private IEnumerator<Transform> path;
        public Transform target;

        public float speed;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            cp = cp.GetComponent<PathGenerator>();
            pathSetter();
            target = GetNextTarget();
            StartCoroutine(MoveToTarget());
        }

        private void Initialize()
        {
        }

        //경로를 셋팅하는 함수 이건 경로만들어주는놈이 만들어서 이터레이터만 넘겨주도록
        private void pathSetter()
        {
            path = cp.GetPath();
        }

        //타겟을 향해서 이동하는 코루틴..상태머신으로 빼봅시다.
        private IEnumerator MoveToTarget()
        {
            var distance = 0f;
            var dir = target.position - transform.position;

            while (true)
            {
                distance = Vector3.Distance(this.transform.position, target.transform.position);
                if (distance <= 0.3f)
                    break;

                transform.LookAt(target);
                rb.MovePosition(transform.localPosition + transform.forward * Time.deltaTime * speed);
                yield return null;
            }

            target = GetNextTarget();
            StartCoroutine(MoveToTarget());

            yield break;
        }

        private void Dead()
        {
            ObjPoolManager.instance.monsterPool.Push(this.gameObject);
        }

        private Transform GetNextTarget()
        {
            if (path.MoveNext() == false)
            {
                path.Reset();
                path.MoveNext();
            }
            return path.Current;
        }
    }
}
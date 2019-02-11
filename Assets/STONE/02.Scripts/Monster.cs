using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Monster : MonoBehaviour
    {
        private IEnumerator<Transform> path;
        public Transform target;
        private Rigidbody rb;

        public float speed;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Initialize()
        {
        }

        //경로를 셋팅하는 함수 이건 경로만들어주는놈이 만들어서 이터레이터만 넘겨주도록
        private void pathSetter(List<Transform> pathlist)
        {
            path = pathlist.GetEnumerator();
        }

        //타겟을 향해서 이동하는 코루틴..상태머신으로 빼봅시다.
        private IEnumerator MoveToTarget()
        {
            float distance = Vector3.Distance(this.transform.position, target.transform.position);
            var dir = target.position - transform.position;
            while (distance > 0.3f)
            {
                distance = Vector3.Distance(this.transform.position, target.transform.position);
                transform.LookAt(target);
                rb.MovePosition(transform.localPosition + transform.forward * Time.deltaTime * speed);
                Debug.Log(distance);
                yield return null;
            }
            target = FindTarget();
            StartCoroutine(MoveToTarget());
            yield break;
        }

        private Transform FindTarget()
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
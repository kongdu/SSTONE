using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Move<T, M> : State<T, M> where T : Monster
                                                where M : GameManager
    {
        public State_Move(T owner)
        {
            Initialize(owner);
        }

        public override void Enter()
        {
            Debug.Log("무브");
            Debug.Log("공격으로");
            owner.StartCoroutine(MoveToTarget());
        }

        public override void Run()
        {
            base.Run();
        }

        public override string NextStatekey()
        {
            return "Attack";
        }

        public override void Exit()
        {
            base.Exit();
        }

        private IEnumerator MoveToTarget()
        {
            var distance = 0f;
            var dir = owner.target.position - owner.transform.position;

            while (true)
            {
                distance = Vector3.Distance(owner.transform.position, owner.target.transform.position);
                if (distance <= 0.3f)
                    break;

                owner.transform.LookAt(owner.target);
                owner.rb.MovePosition(owner.transform.localPosition + owner.transform.forward * Time.deltaTime * info.speed);
                yield return null;
            }

            owner.target = GetNextTarget();
            owner.StartCoroutine(MoveToTarget());

            yield break;
        }

        public Transform GetNextTarget()
        {
            IEnumerator<Transform> path = info.path;
            if (path.MoveNext() == false)
            {
                path.Reset();
                path.MoveNext();
            }
            return path.Current;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class State_Move : State
    {
        public State_Move()
        {
            base.Initialize();
        }

        public override void Enter()
        {
            Debug.Log("무브");
        }

        public override void Run()
        {
            base.Run();
        }

        public override string ChangeState()
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
            var dir = monster.target.position - transform.position;

            while (true)
            {
                distance = Vector3.Distance(this.transform.position, monster.target.transform.position);
                if (distance <= 0.3f)
                    break;

                transform.LookAt(monster.target);
                monster.rb.MovePosition(transform.localPosition + transform.forward * Time.deltaTime * monster.speed);
                yield return null;
            }

            monster.target = GetNextTarget();
            StartCoroutine(MoveToTarget());

            yield break;
        }

        public Transform GetNextTarget()
        {
            IEnumerator<Transform> path = monsterDataBase.path;
            if (path.MoveNext() == false)
            {
                path.Reset();
                path.MoveNext();
            }
            return path.Current;
        }
    }
}
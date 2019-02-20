using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    public class Mover : MonoBehaviour
    {
        // 직접 연결하기
        public Monster monster;

        public event Func<StateIndex> completeMoveOperation = () => { return StateIndex.Attack; };

        // 켜졋을때 이동하는 기능 실행
        private void OnEnable()
        {
            SetTarget();
            StartCoroutine(MoveToTarget());
        }

        private void OnDisable()
        {
            StopCoroutine(MoveToTarget());
        }

        // 타깃으로 이동
        private IEnumerator MoveToTarget()
        {
            var distance = 0f;
            while (true)
            {
                //var dir = owner.target - owner.transform.position;
                //dir.Normalize();
                //owner.transform.rotation = Quaternion.LookRotation(dir);
                this.transform.LookAt(monster.target);
                distance = Vector3.Distance(this.transform.position, monster.target);
                if (distance <= 0.3f)
                { break; }

                //owner.rb.MovePosition(owner.transform.localPosition + owner.transform.forward * Time.deltaTime * owner.speed);
                this.transform.Translate(new Vector3(0, 0, 1 * monster.speed * Time.deltaTime));
                yield return null;
            }
            SerchingNextProcess();
            yield return null;
        }

        // 완료 하면 다음 타깃으로 바꾸는 함수 실행
        private void SetTarget()
        {
            //owner.StartCoroutine(MoveToTarget());
            monster.target = monster.path.Current;
            StartCoroutine(MoveToTarget());
        }

        // 타깃의 종류에 따라서 다시 이동할지 공격을 할지 결정
        private void SerchingNextProcess()
        {
            if (monster.path.MoveNext() == false)
            {
                Debug.Log("다음이터레이터가 없기때문에 리셋합니다.");
                monster.path.Reset();
                completeMoveOperation();
                //SetFinalTarget();
                return;
            }
            else SetTarget();
        }

        private void SetFinalTarget()
        {
            //monster.target = new Vector3(0, 0, 0);
        }
    }
}
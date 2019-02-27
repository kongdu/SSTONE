using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-200)]
    public class MonsterSpawner : MonoBehaviour
    {
        /// <summary>
        /// 몬스터를찍어냅니다.
        /// </summary>
        /// <param name="count">찍어낼횟수</param>
        /// <param name="delay">몬스터를찍어내는시간의간격</param>
        /// <returns></returns>
        public IEnumerator GenerateMonster(int count, float delay = 1f)
        {
            if (delay < 0.5f)
            { delay = 0.5f; }
            for (int i = 0; i < count; i++)
            {
                var monster = ObjPoolManager.instance.monsterPool.Pop();
                monster.transform.position = FindFarPoint(this.transform.position);
                monster.SetActive(true);
                yield return new WaitForSeconds(delay);
            }
        }

        /// <summary>
        /// pivot 기준으로 최소 거리 ~ 최대 거리 사이에 무작위로 위치 생성
        /// </summary>
        /// <returns>생성된 위치</returns>
        public Vector3 FindFarPoint(Vector3 pivot, float minDistance = 90f, float maxDistance = 110f)
        {
            float distance = Random.Range(minDistance, maxDistance);
            float angle = Random.Range(0f, 360f);
            float radian = angle * Mathf.Deg2Rad;
            return pivot + (new Vector3(Mathf.Cos(radian), 0f, Mathf.Sin(radian)) * distance);
        }
    }
}
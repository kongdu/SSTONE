using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class MonsterSpawner : MonoBehaviour
    {
        public Transform[] monsterGeneratezone;

        /// <summary>
        /// 몬스터를찍어냅니다.
        /// </summary>
        /// <param name="count">찍어낼횟수</param>
        /// <param name="delay">몬스터를찍어내는시간의간격</param>
        /// <returns></returns>
        public IEnumerator GenerateMonster(int count, float delay = 1f)
        {
            if (delay < 1f) { delay = 1f; }
            for (int i = 0; i < count; i++)
            {
                int spwanpoint = i % monsterGeneratezone.Length;
                var monster = ObjPoolManager.instance.monsterPool.Pop();
                monster.transform.position = monsterGeneratezone[spwanpoint].transform.position;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
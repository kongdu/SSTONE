using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class MonsterManager : MonoBehaviour
    {
        ObjPoolManager objPoolManager;

        public Transform[] monsterGeneratezone;
                
        IEnumerator GenerateMonster(int duration)
        {
            for (int i = 0; i < duration; i++)
            {
                int spwanpoint = i % monsterGeneratezone.Length;
                var monster = ObjPoolManager.instance.monsterPool.Pop();
                monster.transform.position = monsterGeneratezone[spwanpoint].transform.position;
                monster.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class MonsterManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> monsterPool;

        [SerializeField]
        private List<GameObject> activatedMonster;

        private const int maxCount = 1000;
        public GameObject MonsterPreFab;
        public Transform[] MonsterCreateZone;

        private void Awake()
        {
            for (int i = 0; i < maxCount; i++)
            {
                var monster = GameObject.Instantiate(MonsterPreFab);
                monsterPool.Add(monster);
                monster.SetActive(false);
            }
        }

        public void PopMonster(int mobjencount)
        {
            if (mobjencount >= monsterPool.Count)
            {
                return;
            }
            for (int i = 0; i < mobjencount; i++)
            {
                int MCZIndex = i % MonsterCreateZone.Length;
                monsterPool[i].transform.position = MonsterCreateZone[MCZIndex].transform.position;
                activatedMonster.Add(monsterPool[i].gameObject);
                activatedMonster[i].SetActive(true);
            }
            monsterPool.RemoveRange(0, mobjencount);
        }
    }
}
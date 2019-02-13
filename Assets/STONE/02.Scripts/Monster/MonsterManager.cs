using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class MonsterManager : MonoBehaviour
    {
        public MonsterSpawner monsterSpawner;

        private void Start()
        {
            MonsterGen(50, 1f);
        }

        public void MonsterGen(int generatecount, float timelag)
        {
            StartCoroutine(monsterSpawner.GenerateMonster(generatecount, timelag));
        }
    }
}
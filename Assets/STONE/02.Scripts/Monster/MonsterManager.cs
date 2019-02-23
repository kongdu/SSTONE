using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-150)]
    public class MonsterManager : MonoBehaviour
    {
        public MonsterSpawner monsterSpawner;

        private void Start()
        {
            MonsterGen(1, 5f);
        }

        public void MonsterGen(int generatecount, float timelag)
        {
            StartCoroutine(monsterSpawner.GenerateMonster(generatecount, timelag));
        }
    }
}
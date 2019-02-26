using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class MonsterManager : MonoBehaviour
    {
        public MonsterSpawner monsterSpawner;

        private void Awake()
        {
            //Debug.unityLogger.logEnabled = false;
        }

        private void Start()
        {
            MonsterGen(500, 0.5f);
        }

        public void MonsterGen(int generatecount, float timelag)
        {
            StartCoroutine(monsterSpawner.GenerateMonster(generatecount, timelag));
        }
    }
}
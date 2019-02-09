using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class ObjPoolManager : MonoBehaviour
    {
        public GameObject monsterPrefab;
        private const int maxcount = 1000;
        public ObjPool<GameObject> MonsterPool;

        private void Awake()
        {
            MonsterPool = new ObjPool<GameObject>(maxcount, () => { return GameObject.Instantiate(monsterPrefab, transform); });
        }
    }
}
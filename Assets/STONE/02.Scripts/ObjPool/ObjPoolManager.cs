using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-1000)]
    public class ObjPoolManager : MonoBehaviour
    {
        public Transform monsters;
        public static ObjPoolManager instance = null;

        public ObjPool<GameObject> monsterPool;
        private int maxCount = 20;
        public GameObject monsterPrefab;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            monsterPool = new ObjPool<GameObject>(maxCount, () => GameObject.Instantiate(monsterPrefab, this.transform.position, Quaternion.identity, this.monsters),
                                                 (GameObject some) =>
                                                 {
                                                     if (some.activeSelf == false)
                                                     {
                                                         some.SetActive(true);
                                                     }
                                                     else some.SetActive(false);
                                                 });
        }
    }
}
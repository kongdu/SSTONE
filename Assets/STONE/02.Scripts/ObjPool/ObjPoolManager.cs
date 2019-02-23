using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-700)]
    public class ObjPoolManager : MonoBehaviour
    {
        public static ObjPoolManager instance = null;

        public ObjPool<GameObject> monsterPool;
        private int maxCount = 1;
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
            monsterPool = new ObjPool<GameObject>(
                maxCount,
                () =>
                {
                    Debug.Log("생성");
                    return GameObject.Instantiate(monsterPrefab, this.transform.position, Quaternion.identity, this.transform);
                },
                (GameObject some) =>
                {
                    if (some.activeSelf == false)
                    {
                        some.SetActive(true);
                    }
                    else some.SetActive(false);
                }
            );
        }
    }
}
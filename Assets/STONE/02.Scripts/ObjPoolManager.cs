using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class ObjPoolManager : MonoBehaviour
    {
        public static ObjPoolManager instance = null;
        
        public ObjPool<GameObject> monsterPool;
        private int maxCount = 100;
        public GameObject monsterPrefab;





        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else if(instance != this)
            { 
                    Destroy(gameObject);
            }
            monsterPool = new ObjPool<GameObject>(maxCount, () => GameObject.Instantiate(monsterPrefab, this.transform.position,Quaternion.identity,this.transform));
        }
    }
}
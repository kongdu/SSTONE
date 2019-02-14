using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Monster : MonoBehaviour
    {
        // 몹젠될때 젠된 장소를 나타내는 변수
        public int gateWay = 0;

        public Rigidbody rb;

        public Transform target;

        public float speed;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Initialize()
        {
        }

        private void Dead()
        {
            ObjPoolManager.instance.monsterPool.Push(this.gameObject);
        }
    }
}
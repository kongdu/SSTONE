using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Monster : MonoBehaviour
    {
        public class Info
        {
            public int gateWay = 0;
            public IEnumerator<Transform> path;
            public int damage = 1;
            public float speed = 3f;
        }

        // 몹젠될때 젠된 장소를 나타내는 변수
        public int gateWay = 0;

        public Rigidbody rb;
        public Info info;
        public StateMachine<Monster, GameManager> stateMachine;

        public Transform target;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            info = new Info();
            stateMachine = new StateMachine<Monster, GameManager>();
            stateMachine.Initialize(this);
        }

        // 상태로 뺄 목록 Iv
        private void Dead()
        {
            ObjPoolManager.instance.monsterPool.Push(this.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    [DefaultExecutionOrder(-100)]
    public class Monster : MonoBehaviour
    {
        public IEnumerator<Vector3> path;
        public int damage = 1;
        public float speed = 30f;

        public Rigidbody rb;
        public StateMachine stateMachine;

        public Vector3 target;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            stateMachine = new StateMachine();
            stateMachine.Initialize(this.gameObject);
            stateMachine.StateEnter();
        }

        private void OnEnable()
        {
            stateMachine.StateEnter();
        }
    }
}
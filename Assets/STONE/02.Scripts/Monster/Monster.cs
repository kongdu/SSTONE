using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TMI
{
    [DefaultExecutionOrder(-100)]
    public class Monster : MonoBehaviour
    {
        public int damage = 1;

        public Rigidbody rb;
        public StateMachine stateMachine;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            stateMachine = new StateMachine();
            stateMachine.Initialize(this.gameObject);
        }

        private void OnEnable()
        {
        }

        public void Damaged()
        {
            stateMachine.NextState(StateIndex.Damaged);
        }
    }
}
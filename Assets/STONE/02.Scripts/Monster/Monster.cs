using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Monster : MonoBehaviour
    {
        private Rigidbody rb;
        private StateMachine sm;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            sm = GetComponent<StateMachine>();
        }

        private void Start()
        {
            sm.ChangeState();
        }

        public void Damaged()
        {
            sm.ChangeState(() => GetComponent<Dead>());
        }
    }
}
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

        //private void OnCollisionEnter(Collision collision)
        //{
        //    Debug.Log("1");
        //    if (collision.gameObject.tag == "Camera")
        //    {
        //        Debug.Log("2");
        //        collision.gameObject.GetComponent<Player>().Hittable();
        //    }
        //}
    }
}
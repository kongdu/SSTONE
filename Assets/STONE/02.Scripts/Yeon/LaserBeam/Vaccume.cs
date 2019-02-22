using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    /// <summary>
    /// Vaccume에 붙일 스크립트
    /// </summary>
    public class Vaccume : MonoBehaviour
    {
        private Hittable hitObject;
        public Rigidbody rb;
        public float speed = 1000f;

        private void Start()
        {
            rb.AddForce(transform.forward * speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            hitObject = other.gameObject.GetComponent<Hittable>();

            if (hitObject != null)
            {
                other.gameObject.GetComponent<Hittable>().OnHit();
            }
        }
    }
}
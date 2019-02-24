using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class Monster : MonoBehaviour
    {
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
    }
}
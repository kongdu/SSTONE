using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMI
{
    public class MyTest : MonoBehaviour
    {
        public Monster mons;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Onclick();
            }
        }

        public void Onclick()
        {
            mons.Damaged();
        }
    }
}
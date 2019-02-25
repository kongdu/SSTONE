using System;
using System.Collections;
using UnityEngine;

namespace TMI
{
    public struct StoneInfo
    {
        public Vector3 dir;
        public float power;

        public StoneInfo(Vector3 dir, float power)
        {
            this.dir = dir;
            this.power = power;
        }
    }

    public class StoneBase : MonoBehaviour
    {
        public enum StoneType { None, Laser, Blackhole, Plate, Dimement }

        public static StoneType type;

        public StoneInfo stoneInfo;

        protected Rigidbody rid;

        public static Action DeadEvent = () => { };

        private void Awake()
        {
            rid = GetComponent<Rigidbody>();
        }

        public virtual void Enter(StoneType type)
        {
            StoneBase.type = type;

            rid.useGravity = false;
            rid.constraints = RigidbodyConstraints.None;
            Debug.Log(stoneInfo.dir);
            rid.AddForce(transform.forward * stoneInfo.power * 3, ForceMode.Impulse);
        }

        protected virtual IEnumerator Gravity()
        {
            yield return null;
            yield return new WaitForSeconds(0.3f);
            rid.useGravity = true;
        }
    }
}
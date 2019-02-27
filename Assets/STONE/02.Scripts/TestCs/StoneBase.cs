using System;
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
        public StoneInfo stoneInfo;

        [NonSerialized]
        public Rigidbody rb;

        public static Action DeadEvent = () => { };

        protected Vector3 pos;
        protected Weapon weapon;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            weapon = FindObjectOfType<Weapon>();
        }

        public virtual void Shot()
        {
            //rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(stoneInfo.dir * stoneInfo.power, ForceMode.Impulse);
        }

        public virtual void ResetPos()
        {
            rb.GetComponent<Collider>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.localPosition = pos + Vector3.up * 2f;
            RightController.ControllerPressUp -= weapon.StateAttack;
        }
    }
}
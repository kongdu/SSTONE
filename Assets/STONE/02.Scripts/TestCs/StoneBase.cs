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
        public enum StoneType { None, Laser, Blackhole, Plate, Dimement }

        public static StoneType type;
        public StoneInfo stoneInfo;
        public Rigidbody rid;
        public static Action DeadEvent = () => { };

        protected Vector3 pos;
        protected Weapon weapon;

        private void OnEnable()
        {
            weapon = FindObjectOfType<Weapon>();
        }

        public virtual void Enter(StoneType type)
        {
            StoneBase.type = type;
            rid.constraints = RigidbodyConstraints.None;

            rid.AddForce(stoneInfo.dir * stoneInfo.power * 3, ForceMode.Impulse);
        }

        public virtual void ResetPos()
        {
            rid.GetComponent<Collider>().enabled = false;
            rid.constraints = RigidbodyConstraints.FreezeAll;
            transform.localPosition = pos + Vector3.up * 2f;
            RightController.ControllerPressUp -= weapon.StateAttack;
        }
    }
}
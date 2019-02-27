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
        public bool IsShooting { get; private set; } = false;

        [NonSerialized] public Rigidbody rb;
        [NonSerialized] public MeshRenderer meshRenderer;

        public static Action DeadEvent = () => { };

        protected Vector3 pos;
        protected Weapon weapon;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            weapon = FindObjectOfType<Weapon>();
        }

        public virtual void Shot()
        {
            rb.AddForce(stoneInfo.dir * stoneInfo.power, ForceMode.Impulse);

            IsShooting = true;
        }

        public virtual void ResetInfo()
        {
            transform.localPosition = pos + Vector3.up * 2f;
            rb.velocity = Vector3.zero;

            IsShooting = false;
        }
    }
}
using UnityEngine;

namespace TMI
{
    public class Dimement : StoneBase
    {
        public ParticleSystem ps = null;

        private float radius = 2.0f;

        private Vector3 pos;

        public override void Enter(StoneType type)
        {
            type = StoneType.Dimement;
            base.Enter(type);

            Debug.Log("Dimement");

            StartCoroutine(Gravity());
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(pos, radius);
        }

        private void OnCollisionEnter(Collision collision)
        {
            //gizmo Test
            pos = collision.contacts[0].point;

            var hit = collision.collider.GetComponent<Hittable>();
            if (hit == null)
                return;

            //쓰고난 후 임의의 장소에 날려버리고 고정
            transform.position = Vector3.one * 99;
            rid.constraints = RigidbodyConstraints.FreezeAll;

            var findobjs = GameEffectManager.Instance.FindRangeObj(collision, radius);

            foreach (var item in findobjs)
            {
                var mob = item.GetComponent<Hittable>();
                mob.OnHit();
            }
        }
    }
}
using UnityEngine;

namespace TMI
{
    public class Dimement : StoneBase
    {
        private float radius = 2.0f;

        public override void Enter(StoneType type)
        {
            type = StoneType.Dimement;
            base.Enter(type);

            //Debug.Log("Dimement");
        }

        private Vector3 pos = new Vector3(99, 99, 99);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pos, 3);
        }

        private void OnCollisionEnter(Collision collision)
        {
            pos = collision.contacts[0].point;

            var hit = collision.collider.GetComponent<Hittable>();
            if (hit == null)
                return;

            ResetPos();
            var findobjs = GameEffectManager.Instance.FindRangeObj(collision, radius);

            foreach (var item in findobjs)
            {
                var mob = item.GetComponent<Hittable>();
                mob.OnHit();
            }
        }
    }
}